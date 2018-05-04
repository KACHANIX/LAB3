using System;
using System.Net.Sockets;
namespace Client.IO
{
    public static class NetClientIO
    {
        public static Socket server;
        public static void WriteReceived()
        {
            try
            {
                Console.Write(server.TcpReceiveMessage());
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.ConnectionReset)
                {
                    Console.WriteLine("\nConnection lost!");
                }
            }
        }

        public static void WriteLineReceived()
        {
            try
            {
                Console.Write(server.TcpReceiveMessage() + "\n");
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.ConnectionReset)
                {
                    Console.WriteLine("\nConnection lost!");
                }
            }
        }

        public static string Receive()
        {
            try { 
                return server.TcpReceiveMessage();
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.ConnectionReset)
                {
                    Console.WriteLine("\nConnection lost!");
                }
                return "GOODBYE!";
            }
        }

        public static void ReadLine()
        {
            try
            {

            
            string msg = Console.ReadLine();
            while (msg == string.Empty)
            {
                Console.WriteLine("Empty string, try again");
                msg = Console.ReadLine();
            }
            server.TcpSendMessage(msg);
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.ConnectionReset)
                {
                    Console.WriteLine("\nConnection lost!");
                }
            }
        }

    }
    
}
