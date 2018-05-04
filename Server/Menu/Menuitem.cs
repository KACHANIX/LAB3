using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SERVER.Menu
{
    public delegate bool FUN(Socket socket);
    public class MenuItem
    {
        public string Description;
        public FUN Action;
        public ConsoleKey Key;
    }
}
