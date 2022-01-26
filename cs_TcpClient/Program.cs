using System;
using System.IO;
using System.Net.Sockets;

namespace cs_TcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TcpClient();
            client.Connect("127.0.0.1", 45001);

            var stream = client.GetStream();
            var bw = new BinaryWriter(stream);
            var br = new BinaryReader(stream);

            while (true)
            {
                var str = Console.ReadLine();
                bw.Write(str);
                var answer = br.ReadString();
                Console.WriteLine($"Server: {answer}");
            }

        }
    }
}
