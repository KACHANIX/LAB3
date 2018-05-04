using System;
using System.Net;
using System.Net.Sockets;
using Client.IO;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
                var targetIp = IPAddress.Parse("127.0.0.1");
                int port = 904;
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(targetIp, port);
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.ConnectionRefused)
                {
                    Console.WriteLine("\nServer's not launched!");
                }
            }
            NetClientIO.server = socket;
                bool myProgrammIsRunning = true;
                while (myProgrammIsRunning)
                {
                    int i = 0;
                    while (i < 6)
                    {
                        NetClientIO.WriteLineReceived();
                        i++;
                    }

                    string Received = "Wrong input, try again";
                    while (Received == "Wrong input, try again")
                    {
                        NetClientIO.ReadLine();
                        Console.WriteLine(Received = NetClientIO.Receive());
                    }

                    switch (Received)
                    {
                        case "\nInput the year in next format:\nYYYY : ":
                            myProgrammIsRunning = Functional.Check();
                            break;
                        case "\nInput the first Date in next format:\nDD/MM/YYYY : ":
                            myProgrammIsRunning = Functional.Calc();
                            break;
                        case "\nInput the Date in next format:\nDD/MM/YYYY : ":
                            myProgrammIsRunning = Functional.Day();
                            break;
                        case "GOODBYE!":
                            myProgrammIsRunning = false;
                            NetClientIO.server.Close();
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
                Console.ReadKey();
            //}
            //catch (SocketException ex)
            //{
            //    if (ex.SocketErrorCode == SocketError.ConnectionReset)
            //    {
            //        Console.WriteLine("\nConnection lost!");
            //    }
            //    if (ex.SocketErrorCode == SocketError.ConnectionRefused)
            //    {
            //        Console.WriteLine("\nServer's not launched!");
            //    }
            //    Console.ReadKey();
            //}
        }
    }
}
