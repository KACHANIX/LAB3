using SERVER.IO;
using System;
using System.Net.Sockets;
using System.Threading;

namespace SERVER
{
    static class Functions
    {
        public static bool Check(Socket client)
        {
            NetServerIO io = new NetServerIO();
            io.Write("\nInput the year in next format:\nYYYY : ", client);
            string yearInput = io.ReadLine(client);
            int year = 0;
            while (!int.TryParse(yearInput, out year) || !(year >= 1 && year <= 9999))
            {
                io.Write("Wrong input, Year must be in interval (1, 9999), Try again", client);
                yearInput = io.ReadLine(client);
                System.Threading.Thread.Sleep(15);
            }
            System.Threading.Thread.Sleep(15);
            if (DateTime.IsLeapYear(year))
            {
                io.Write($"\n___________\n{year} is leap\n___________\n", client);
            }
            else
            {
                io.Write($"\n___________\n{year} isn't leap\n___________\n", client);
            }

            return true;
        }
        public static bool Calc(Socket client)
        {
            NetServerIO io = new NetServerIO();
            io.Write("\nInput the first Date in next format:\n" +
               "DD/MM/YYYY : ", client);
            string dateinp = io.ReadLine(client);
            DateTime date1;
            while (!(DateTime.TryParse(dateinp, out date1)))
            {
                io.Write($"  Unable to parse '{dateinp}'." +
                    $"\nInput the first Date in next format:\n" +
                    "DD/MM/YYYY : ", client);
                dateinp = io.ReadLine(client);
                System.Threading.Thread.Sleep(15);
            }
            io.Write("Input the second Date in next format:\n" +
               "DD/MM/YYYY : ", client);
            System.Threading.Thread.Sleep(15);
            dateinp = io.ReadLine(client);
            DateTime date2;
            while (!(DateTime.TryParse(dateinp, out date2)))
            {
                io.Write($"  Unable to parse '{dateinp}'." +
                    "Input the second Date in next format:\n" +
                    "DD/MM/YYYY : ", client);
                dateinp = io.ReadLine(client);
                System.Threading.Thread.Sleep(15);
            }

            if (date1 > date2)
            {
                DateTime tmp = date1;
                date1 = date2;
                date2 = tmp;
            }
            System.Threading.Thread.Sleep(15);
            double difdates = (date2 - date1).TotalDays;
            io.Write($"\n\n___________\nThe difference between dates is {difdates} day(s)\n___________\n", client);

            Serializing.SerializeIn(date1, date2);

            return true;
        }
        public static bool Day(Socket client)
        {
            NetServerIO io = new NetServerIO();
            io.Write("\nInput the Date in next format:\n" +
               "DD/MM/YYYY : ", client);
            string dateinp = io.ReadLine(client);
            DateTime date1;
            while (!(DateTime.TryParse(dateinp, out date1)))
            {
                System.Threading.Thread.Sleep(15);
                io.Write(
                    $"  Unable to parse '{dateinp}'." +
                    "\nInput the Date in next format:\n" +
                    "DD/MM/YYYY : ", client);
                dateinp = io.ReadLine(client);
                System.Threading.Thread.Sleep(15);
            }
            System.Threading.Thread.Sleep(15);
            io.Write($"\n\n___________\nIt's {date1.DayOfWeek}\n___________", client);
            return true;
        }
        public static bool Quit(Socket client)
        {
            NetServerIO io = new NetServerIO();
            Console.WriteLine($"Client disconnected, closing thread №{Thread.CurrentThread.ManagedThreadId}");
            io.Write("GOODBYE!", client);
            client.Close();
            return false;
        }
    }
}
