using System.Net.Sockets;
namespace SERVER.IO
{
    public class NetServerIO
    {
        public void Write(string msg, Socket client)
        {

            System.Threading.Thread.Sleep(15);
            client.TcpSendMessage(msg);
            System.Threading.Thread.Sleep(15);
        }
        
        public string ReadLine(Socket client)
        {
            return client.TcpReceiveMessage();
        }
    }
}
