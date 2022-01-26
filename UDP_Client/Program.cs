using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.Udp);


            var ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 45678);

            while (true)
            {
                var str = Console.ReadLine();
                var bytes = Encoding.Default.GetBytes(str);
                client.SendTo(bytes, ep);
            }
        }
    }
}
