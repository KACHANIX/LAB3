using System.Net.Sockets;
using System.Text;

namespace Client
{
    public static class NETHELP
    {
        public static string TcpReceiveMessage(this Socket socket)
        {
            var data = new byte[64];
            var builder = new StringBuilder();
            var bytes = 0;

            do
            {
                bytes = socket.Receive(data);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);

            return builder.ToString();
        }
        
        public static void TcpSendMessage(this Socket socket, string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            socket.Send(data);
        }
        
    }
}