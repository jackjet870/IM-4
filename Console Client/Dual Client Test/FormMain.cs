using HttpFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace Dual_Client_Test
{
    public partial class FormMain : Form
    {
        private bool safeExit;

        public FormMain()
        {
            InitializeComponent();

            this.hostServer.MessageRecieved += (messageBytes, request) =>
            {
                string messageAsString = messageBytes.WebBytesToString();

                string[] messageParts = messageAsString.Split('\a');

                if (messageParts[0] == "POST")
                {
                    int metadataLength = (messageParts[0] + '\a' + messageParts[1] + '\a').ToWebBytes().Length;
                    byte[] messagaDataBytes = new byte[messageBytes.Length - metadataLength];
                    for (int index = metadataLength; index < messageBytes.Length; index++)
                    {
                        messagaDataBytes[index - metadataLength] = messageBytes[index];
                    }

                    Message messageData = (Message)Serialization.Deserialize(messagaDataBytes);
                    // Is post message - transmitting message to server
                    if (messageParts[1] != messageData.UserID)
                    {
                        Console.WriteLine("Unauthorized message recieved: " + messageData.ToString());
                        return new byte[0];
                    }

                    if (messageData.UserID == this.userIDs[0])
                    {
                        // Conversation 1
                        lock (this.conversation1ServerMessages)
                        {
                            Console.WriteLine("Enqueued " + messageData);
                            this.conversation1ServerMessages.Enqueue(messageData);
                        }
                    }
                    else if (messageData.UserID == this.userIDs[1])
                    {
                        // Conversation 2
                        lock (this.conversation2ServerMessages)
                        {
                            Console.WriteLine("Enqueued " + messageData);
                            this.conversation2ServerMessages.Enqueue(messageData);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unrecognised user (POST): " + messageData.ToString());
                        return new byte[0];
                    }
                }
                else if (messageParts[0] == "GET")
                {
                    // Is retrieval message - getting messages from server
                    if (messageParts[1] == this.userIDs[0])
                    {
                        // Conversation 1
                        lock (this.conversation1ServerMessages)
                        {
                            if (this.conversation1ServerMessages.Count > 0)
                            {
                                Message messageToSend = this.conversation1ServerMessages.Dequeue();
                                Console.WriteLine("Transmitted message: " + messageToSend.ToString());
                                return Serialization.Serialize(messageToSend);
                            }
                            else
                            {
                                return new byte[0];
                            }
                        }
                    }
                    else if (messageParts[1] == this.userIDs[1])
                    {
                        // Conversation 2
                        lock (this.conversation2ServerMessages)
                        {
                            if (this.conversation2ServerMessages.Count > 0)
                            {
                                Message messageToSend = this.conversation2ServerMessages.Dequeue();
                                Console.WriteLine("Transmitted message: " + messageToSend.ToString());
                                return Serialization.Serialize(messageToSend);
                            }
                            else
                            {
                                return new byte[0];
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unrecognised user (GET): " + messageAsString);
                        return new byte[0];
                    }
                }
                else Console.WriteLine("Invalid input recieved: " + messageAsString);

                return new byte[0];
            };

            this.Conversation1MessageGetter = new Thread(() => GetMessages(this.userIDs[0]));

            this.Conversation2MessageGetter = new Thread(() => GetMessages(this.userIDs[1]));

            this.Conversation1MessageGetter.Start();

            this.Conversation2MessageGetter.Start();
        }

        private const string ServerUrl = "http://localhost:8080/";

        private readonly string[] userIDs = { "User1", "User2" };

        private Thread Conversation1MessageGetter { get; }

        private Thread Conversation2MessageGetter { get; }

        private readonly Queue<Message> conversation1ServerMessages = new Queue<Message>();

        private readonly Queue<Message> conversation2ServerMessages = new Queue<Message>();

        private readonly Queue<Message> conversation1Messages = new Queue<Message>();

        private readonly Queue<Message> conversation2Messages = new Queue<Message>();

        private readonly Server hostServer = new Server(8080);

        private void txtMessage1_KeyDown(object sender, KeyEventArgs e) => txtMessageKeyDown(e, true);

        private void txtConversation2_KeyDown(object sender, KeyEventArgs e) => txtMessageKeyDown(e, false);

        // ReSharper disable once InconsistentNaming
        private void txtMessageKeyDown(KeyEventArgs e, bool conversation1)
        {
            if (e.KeyCode == Keys.Return && e.Modifiers == Keys.None)
            {
                // Click relevant button
                if (conversation1)
                {
                    this.btnSend1.PerformClick();
                }
                else
                {
                    this.btnSend2.PerformClick();
                }
            }
        }

        private void WriteMessageToConversationLog(Message messageToLog, bool conversation1)
        {
            string preparedMessage = string.Empty;

            preparedMessage += messageToLog.ReceivedDateTime.ToShortDateString() + " " + messageToLog.ReceivedDateTime.ToShortTimeString();

            preparedMessage += Environment.NewLine;

            preparedMessage += messageToLog.UserID == this.userIDs[conversation1 ? 0 : 1] ? "Me" : this.userIDs[conversation1 ? 0 : 1];

            preparedMessage += Environment.NewLine;

            preparedMessage += messageToLog.MessageContents;

            preparedMessage += Environment.NewLine + Environment.NewLine;

            if (conversation1)
            {
                this.txtConversation1.Text += preparedMessage;
            }
            else
            {
                this.txtConversation2.Text += preparedMessage;
            }
        }

        private void btnSend1_Click(object sender, EventArgs e)
        {
            SendMessage(this.txtMessage1.Text, true);

            WriteMessageToConversationLog(new Message(this.txtMessage1.Text, this.userIDs[0]), true);

            this.txtMessage1.Text = string.Empty;
        }

        private void btnSend2_Click(object sender, EventArgs e)
        {
            SendMessage(this.txtMessage2.Text, false);

            WriteMessageToConversationLog(new Message(this.txtMessage2.Text, this.userIDs[1]), false);

            this.txtMessage2.Text = string.Empty;
        }

        private void SendMessage(string message, bool conversation1)
        {
            string metadata = "POST\a" + this.userIDs[conversation1 ? 0 : 1] + '\a';

            byte[] metadataAsBytes = metadata.ToWebBytes();

            byte[] messageAsBytes = Serialization.Serialize(new Message(message, conversation1 ? this.userIDs[0] : this.userIDs[1]));

            byte[] bytesToSend = new byte[metadataAsBytes.Length + messageAsBytes.Length];

            metadataAsBytes.CopyTo(bytesToSend, 0);

            messageAsBytes.CopyTo(bytesToSend, metadataAsBytes.Length);

            Client.SendData(bytesToSend, ServerUrl);
        }

        private void tmrRefresh_Tick(object sender, EventArgs e) => RefreshConversationHistory();

        private void RefreshConversationHistory()
        {
            lock (this.conversation1Messages)
            {
                while (this.conversation1Messages.Count > 0)
                {
                    WriteMessageToConversationLog(this.conversation1Messages.Dequeue(), false);
                }
            }

            lock (this.conversation2Messages)
            {
                while (this.conversation2Messages.Count > 0)
                {
                    WriteMessageToConversationLog(this.conversation2Messages.Dequeue(), true);
                }
            }
        }

        private void GetMessages(string userID)
        {
            while (!this.safeExit)
            {
                byte[] recievedBytes = Client.SendData(("GET\a" + userID).ToWebBytes(), ServerUrl);

                if (recievedBytes.Length > 0)
                {
                    if (userID == this.userIDs[0])
                    {
                        // Conversation 1
                        lock (this.conversation1Messages)
                        {
                            this.conversation1Messages.Enqueue((Message)Serialization.Deserialize(recievedBytes));
                        }
                    }
                    else if (userID == this.userIDs[1])
                    {
                        // Conversation 2
                        lock (this.conversation1Messages)
                        {
                            this.conversation2Messages.Enqueue((Message)Serialization.Deserialize(recievedBytes));
                        }
                    }
                }

                Thread.Sleep(100);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.safeExit = true;

            this.hostServer.Dispose();
        }
    }

    [Serializable]
    class Message
    {
        public string MessageContents { get; }

        public DateTime ReceivedDateTime { get; }

        public string UserID { get; }

        public Message(string messageContents, string userID)
        {
            this.ReceivedDateTime = DateTime.Now;

            this.MessageContents = messageContents;

            this.UserID = userID;
        }

        public override string ToString()
        {
            return nameof(this.UserID) + ": " + this.UserID + ", " + nameof(this.ReceivedDateTime) + ": " + this.ReceivedDateTime + ", " +
                nameof(this.MessageContents) + ": " + Environment.NewLine + this.MessageContents;
        }
    }

    static class Serialization
    {
        private static readonly BinaryFormatter MyFormatter = new BinaryFormatter { TypeFormat = FormatterTypeStyle.TypesWhenNeeded };

        public static byte[] Serialize(object serializeThis)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                lock (MyFormatter)
                {
                    MyFormatter.Serialize(ms, serializeThis);
                }

                return ms.ToArray();
            }
        }

        public static object Deserialize(byte[] deserializeThis)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(deserializeThis, 0, deserializeThis.Length);

                ms.Position = 0;

                lock (MyFormatter)
                {
                    return MyFormatter.Deserialize(ms);
                }
            }
        }
    }
}
