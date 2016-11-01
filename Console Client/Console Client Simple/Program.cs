using HttpFramework;
using System;

namespace Console_Client_Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter a message to transmit");

                Console.WriteLine(Client.SendData(Console.ReadLine(), "http://localhost:8080"));

                Console.WriteLine("Requesting data...");

                Console.WriteLine(Client.GetData("http://localhost:8080").WebBytesToString());
            }
        }
    }
}
