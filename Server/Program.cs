using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace SERVER
{
    class Program
    {
        public static void Start(object SocketClient)
        {
            Socket client = (Socket)SocketClient;
            Console.WriteLine($"New client Connected, starting new thread" +
                $" №{Thread.CurrentThread.ManagedThreadId}");
            var mainmenu = new Menu.Menu();
            bool myProgramIsRunning = true;
            mainmenu.AddItem("Check if year is leap", Functions.Check);
            mainmenu.AddItem("Calculate interval between dates", Functions.Calc);
            mainmenu.AddItem("Get the name of day of week", Functions.Day);
            mainmenu.AddItem("Serialize interval from last query", Serializing.SerializeFrom);
            mainmenu.AddItem("Quit", Functions.Quit);
            while (myProgramIsRunning)
            {
                myProgramIsRunning = mainmenu.Display(client);
            }
        }

        static void Main(string[] args)
        {
            var ip = IPAddress.Parse("127.0.0.1");
            int port = 904;

            const int backlog = 1;
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var currentEndPoint = new IPEndPoint(IPAddress.Loopback, port);
            socket.Bind(currentEndPoint);
            socket.Listen(backlog);
            Console.WriteLine("Listening...");
            while (true)
            {
                Socket client = socket.Accept();
                ParameterizedThreadStart _start = new ParameterizedThreadStart(Start);
                Thread thread = new Thread(_start);
                object socketclient = client;
                thread.Start(socketclient);
                
                
            }
        }
    }
}
