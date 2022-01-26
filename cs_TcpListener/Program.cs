using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace cs_TcpListener
{
    class Program
    {
        static void Main(string[] args)
        {
            var ip = IPAddress.Parse("127.0.0.1");
            var listener = new TcpListener(ip, 45001);

            listener.Start(100); // Listen

            while (true)
            {
                // listener.AcceptSocket();
                var client = listener.AcceptTcpClient();

                var stream = client.GetStream();
                var bw = new BinaryWriter(stream);
                var br = new BinaryReader(stream);


                while (true)
                {
                    var data = br.ReadString();
                    Console.WriteLine(data);
                    bw.Write("Roger that !");
                }
            }

        }
    }
}
