using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Server
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
    }

    public static class MessagesMetadata
    {
        public static int TotalSent { get; private set; }

        private static List<DateTime> messagesSentDateTimes = new List<DateTime>();

        public static int UsersLoggedIn { get; private set; }

        public static int SentLastMinute
        {
            get
            {
                DateTime nearlyNow = DateTime.Now.AddMinutes(-1);

                lock (messagesSentDateTimes)
                {
                    messagesSentDateTimes = messagesSentDateTimes.Where(x => x > nearlyNow).ToList();

                    return messagesSentDateTimes.Count;
                }
            }
        }

        public static void SendMessage()
        {
            TotalSent++;

            lock (messagesSentDateTimes)
            {
                messagesSentDateTimes.Add(DateTime.Now);
            }
        }

        public static void UserLoggedOut() => UsersLoggedIn--;

        public static void UserLoggedIn() => UsersLoggedIn++;
    }
}
