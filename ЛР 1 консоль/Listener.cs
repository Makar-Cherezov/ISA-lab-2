using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NetConnection;

namespace Server
{
    
    class Listener
    {
        public Controller controller;
        public void FillRequest(ref Request req)
        {
            switch (req.Action)
            {
                case "SetAndCheckPath":
                    string isSuccess = controller.SetAndCheckPath(req.Content[0]).ToString();
                    req.Content = new List<string> { isSuccess };
                    break;
                case "GetFullData":
                    List<string> list = controller.GetFullData();
                    req.Content = list;
                    break;
                case "GetLineByNumber":
                    string line = controller.GetLineByNumber(int.Parse(req.Content[0]));
                    req.Content = new List<string> { line };
                    break;
                case "SaveNewData":
                    controller.SaveNewData(req.Content);
                    break;
                case "DeleteData":
                    controller.DeleteData(int.Parse(req.Content[0]));
                    break;
                case "Shutdown":
                    // как остановить программу
                    break;
                default:
                    req.Content = new List<string> { "Unexpected behaviour" };
                    break;


            }
        }

        public async Task AnswerRequestAsync(NetworkStream stream)
        {
            List<byte> data = new List<byte>();
            while (stream.DataAvailable)
            {
                data.Add((byte)stream.ReadByte());
            }
            string json = Encoding.UTF8.GetString(data.ToArray());
            Request request = Request.GetRequest(json);
            FillRequest(ref request);
            string responseJson = request.GetJson();
            await stream.WriteAsync(Encoding.UTF8.GetBytes(responseJson));
        }
        public async void Main(string[] args)
        {
            controller = new Controller(';');
            TcpListener server = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 8080);
            try
            {
                server.Start();
                while (true)
                {
                    using var tcpClient = await server.AcceptTcpClientAsync();
                    NetworkStream stream = tcpClient.GetStream();
                    await AnswerRequestAsync(stream);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                server.Stop();
                //очистить клиент и поток
                
            }




            

        }
    }
}
