using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using NetConnection;

namespace Server
{
    
    class Listener
    {
        private readonly TcpListener TcpServer;
        private readonly NetworkStream Stream;
        public Request GetRequest()
        {
            List<byte> data = new List<byte>();
            while (stream.DataAvailable)
            {
                data.Add((byte)stream.ReadByte());
            }
            string json = Encoding.UTF8.GetString(data.ToArray());
            string responseJson = ""; // TODO: generate response JSON
            stream.Write(Encoding.UTF8.GetBytes(responseJson));
        }
        public static void Main(string[] args)
        {
            Controller controller = new Controller(';');
            TcpServer = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 8080);
            server.Start();
            TcpClient client = server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();


            
            
            
            stream.Close();
            client.Close();
            server.Stop();

        }
    }
}
