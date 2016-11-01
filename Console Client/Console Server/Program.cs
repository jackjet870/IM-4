using HttpFramework;
using System;

namespace Console_Server
{
    class Program
    {
        private static void Main()
        {
            using (Server myServer = new Server(8080))
            {
                myServer.MessageRecieved +=
                    (message, request) =>
                    {
                        if (request.HttpMethod == "GET")
                        {
                            return "We got your GET request!".ToWebBytes();
                        }

                        return
                            (message.WebBytesToString().Length +
                                " characters recieved").ToWebBytes();
                    };

                Console.ReadKey(true);
            }
        }
    }
}
