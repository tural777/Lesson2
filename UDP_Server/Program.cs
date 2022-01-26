using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Server
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var listener = new Socket(
        //        AddressFamily.InterNetwork, 
        //        SocketType.Dgram, 
        //        ProtocolType.Udp);



        //    var listenerEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 45678);
        //    listener.Bind(listenerEP);

        //    var buffer = new byte[ushort.MaxValue];


        //    // accept  => client_socket
        //    // receive => data
        //    EndPoint ep = new IPEndPoint(IPAddress.Any, 0);


        //    while (true)
        //    {
        //        var len = listener.ReceiveFrom(buffer, ref ep);
        //        var str = Encoding.Default.GetString(buffer, 0, len);
        //        Console.WriteLine($"{ep}: {str}");
        //    }
        //}




        static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();

        static async Task MainAsync(string[] args)
        {
            var listener = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.Udp);



            var listenerEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 45678);
            listener.Bind(listenerEP);

            EndPoint ep = new IPEndPoint(IPAddress.Any, 0);


            var buffer = new byte[ushort.MaxValue];
            var segment = new ArraySegment<byte>(buffer);

            while (true)
            {
                var resp = await listener.ReceiveFromAsync(segment, SocketFlags.None, ep);
                var len = resp.ReceivedBytes;
                var endPoint = resp.RemoteEndPoint;
                var str = Encoding.Default.GetString(buffer, 0, len);
                Console.WriteLine($"{endPoint}: {str}");
            }

        }
    }
}
