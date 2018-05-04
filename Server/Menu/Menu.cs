using System;
using System.Collections.Generic;
using System.Net.Sockets;
using SERVER.IO;

namespace SERVER.Menu
{
    public class Menu
    {
        private List<MenuItem> _items = new List<MenuItem>();
        public void AddItem(string desc, FUN a)
        {
            var item = new MenuItem
            {
                Action = a,
                Description = desc,
                Key = (ConsoleKey)(_items.Count + 49)
            };
            _items.Add(item);
        }
        public bool Display(Socket client)
        {
            NetServerIO io = new NetServerIO();
            int i = 1;
            foreach (MenuItem item in _items)
            {
                io.Write($"{i++}. {item.Description}", client);
            }

            io.Write("Your input : ", client);
            bool isKey = false;
            while (!isKey)
            {
                string KeyInput = io.ReadLine(client);
                string strinput = "D" + KeyInput;
                Console.WriteLine(strinput);
                Enum.TryParse(strinput.ToString(), out ConsoleKey input);
                foreach (MenuItem item in _items)
                {
                    if (item.Key == input)
                    {
                        isKey = true;
                        return item.Action(client);
                    }
                }
                if (!isKey)
                {
                    io.Write("Wrong input, try again", client);
                }
            }
            return true;
        }
    }
}
