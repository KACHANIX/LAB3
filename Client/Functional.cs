using System;
using Client.IO;
namespace Client
{
    public static class Functional
    {
        public static bool Check()
        {
            NetClientIO.ReadLine();
            string msg = NetClientIO.Receive();
            Console.WriteLine(msg);
            while (msg == "Wrong input, Year must be in interval (1, 9999), Try again")
            {
                NetClientIO.ReadLine();
                msg = NetClientIO.Receive();
                Console.WriteLine(msg);
            }
            return true;
        }
        public static bool Calc()
        {
            NetClientIO.ReadLine();
            string msg = NetClientIO.Receive();
            Console.WriteLine(msg);
            while (msg != "Input the second Date in next format:\nDD/MM/YYYY : ")
            {
                NetClientIO.ReadLine();
                msg = NetClientIO.Receive();
                Console.WriteLine(msg);
                System.Threading.Thread.Sleep(15);
            }
            NetClientIO.ReadLine();
            msg = NetClientIO.Receive();
            Console.WriteLine(msg);
            while (msg.Substring(0, 2) == "  ")
            {
                NetClientIO.ReadLine();
                msg = NetClientIO.Receive();
                Console.WriteLine(msg);
                System.Threading.Thread.Sleep(15);
            }
            return true;
        }
        public static bool Day()
        {
            NetClientIO.ReadLine();
            string msg = NetClientIO.Receive();
            Console.WriteLine(msg);
            while (msg.Substring(0, 2) == "  ")
            {
                NetClientIO.ReadLine();
                msg = NetClientIO.Receive();
                Console.WriteLine(msg);
            }
            
            return true;
        }
        public static bool SerializeFrom()
        {
            return true;
        }
        public static bool Quit()
        {
            return false;
        }
    }
}
