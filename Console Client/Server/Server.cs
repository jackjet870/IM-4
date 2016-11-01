using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// Asynchronious request management services
    /// </summary>
    public class Server : IDisposable
    {
        private HttpListener Listener { get; }

        private Thread ListenerThread { get; }

        private bool SafeExit { get; set; }

        public delegate byte[] MessageReceivedEvent(byte[] message, HttpListenerRequest request);

        /// <summary>
        /// Any methods assigned to this event must be thread-safe
        /// </summary>
        public event MessageReceivedEvent MessageRecieved;

        /// <summary>
        /// Initializes a new <see cref="Server"/> using the specified port on the local host machine
        /// </summary>
        /// <param name="portId">The port to listen on</param>
        public Server(params int[] portId) : this(portId.Select(x => "http://localhost:" + x + "/").ToArray())
        {
        }

        /// <summary>
        /// Initializes a new <see cref="Server"/> listening to the specified Uri strings
        /// </summary>
        /// <param name="listeningUriStrings"></param>
        public Server(params string[] listeningUriStrings)
        {
            this.Listener = new HttpListener();
            foreach (string port in listeningUriStrings)
            {
                this.Listener.Prefixes.Add(port);
            }

            this.ListenerThread = new Thread(ListenerMethod);
            this.ListenerThread.Start();
        }

        /// <summary>
        /// The method which contains the actual work for the HttpListener. Meant to be threaded seperately and almost self-contained (except for the events)
        /// </summary>
        private void ListenerMethod()
        {
            if (this.Listener == null)
            {
                throw new ArgumentNullException(nameof(this.Listener));
            }

            List<Task> myTasks = new List<Task>(5);
            try
            {
                this.Listener.Start();
                while (!this.SafeExit)
                {
                    HttpListenerContext context;
                    try
                    {
                        context = this.Listener.GetContext();
                    }
                    catch
                    {
                        if (this.SafeExit)
                            return;
                        else throw;
                    }

                    myTasks.Add(Task.Factory.StartNew(myContext => RequestProcessor((HttpListenerContext)myContext), context));

                    List<Task> taskBuffer = new List<Task>(myTasks.Count);

                    foreach (Task t in myTasks)
                    {
                        if (!t.IsCompleted && !t.IsCanceled)
                        {
                            taskBuffer.Add(t);
                        }
                    }

                    // Modified version of TrimExcess
                    if (taskBuffer.Capacity > taskBuffer.Count * 2 && taskBuffer.Count > 10) // Worth trimming
                    {
                        taskBuffer.Capacity = taskBuffer.Count + 5;
                    }

                    myTasks = taskBuffer;
                }
            }
            finally
            {
                this.Listener.Stop();

                Task.WaitAll(myTasks.ToArray());
            }
        }

        private void RequestProcessor(HttpListenerContext context)
        {
            byte[] response;

            {
                // The input from the user
                HttpListenerRequest request = context.Request;

                using (Stream s = request.InputStream)
                {
                    byte[] returnBytes = new byte[request.ContentLength64];

                    s.Read(returnBytes, 0, returnBytes.Length);

                    response = MessageRecieved?.Invoke(returnBytes, request);
                }
            }

            if (response != null)
            {
                context.Response.ContentLength64 = response.Length;
                using (Stream stream = context.Response.OutputStream)
                {
                    stream.Write(response, 0, response.Length);
                }
            }
        }

        /// <summary>
        /// Terminates the HttpListener. Optionally waits for the listener to fully exit before returning
        /// </summary>
        /// <param name="waitForExit">Whether to wait for the listener to fully exit before returning</param>
        public void Close(bool waitForExit)
        {
            this.SafeExit = true;
            this.Listener.Stop();

            if (waitForExit)
            {
                while (this.ListenerThread != null && this.ListenerThread.IsAlive)
                {
                    Thread.Sleep(20);
                }
            }
        }

        public void Dispose()
        {
            Close(true);

            MessageRecieved = null;
        }
    }
}
