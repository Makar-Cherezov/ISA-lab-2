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
        private static string ModelType { get; set; }
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public static void FillRequest(ref Request req)
        {
            switch (req.Action)
            {
                case "SetModelType":
                    ModelType = req.Content[0];
                    break;
                case "SetAndCheckPath":
                    string isSuccess = Controller.GetInstance(ModelType).SetAndCheckPath(req.Content[0]).ToString();
                    req.Content = new List<string> { isSuccess };
                    break;
                case "GetFullData":
                    List<string> list = Controller.GetInstance(ModelType).GetFullData();
                    req.Content = list;
                    break;
                case "GetLineByNumber":
                    try
                    {
                        string line = Controller.GetInstance(ModelType).GetLineByNumber(int.Parse(req.Content[0]));
                        req.Content = new List<string> { line };
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message);
                        req.Content = new List<string> { "Такой строки нет в файле!\n" };
                    }
                    break;
                case "SaveNewData":
                    Controller.GetInstance(ModelType).SaveNewData(req.Content);
                    break;
                case "DeleteData":
                    try
                    {
                        Controller.GetInstance(ModelType).DeleteData(int.Parse(req.Content[0]));
                        req.Content = new List<string> { "True" };
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message);
                        req.Content = new List<string> { "False" };
                    }
                    break;
                case "Shutdown":
                    Logger.Info("Клиент был отключён.");
                    break;
                default:
                    req.Content = new List<string> { "Unexpected behaviour" };
                    break;


            }
        }

        public static async Task AnswerRequestAsync(NetworkStream stream) 
        {
            try
            {
                while (true)
                {
                    List<byte> data = new List<byte>();
                    while (!stream.DataAvailable) ;
                    while (stream.DataAvailable)
                    {
                        data.Add((byte)stream.ReadByte());
                    }
                    string json = Encoding.Unicode.GetString(data.ToArray());
                    Request request = Request.GetRequest(json);
                    FillRequest(ref request);
                    string responseJson = request.GetJson();
                    await stream.WriteAsync(Encoding.Unicode.GetBytes(responseJson));
                }
            }
            catch (Exception ex)
            {
                Logger.Info(ex.Message);
            }
        }
        static async Task Main(string[] args)
        {
            TcpListener server = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 8080);
            try
            {
                server.Start();
                Console.WriteLine("Сервер запущен");
                while (true)
                {
                    using var tcpClient = await server.AcceptTcpClientAsync();
                    Console.WriteLine("Установлено соединение с клиентом");
                    Logger.Info("Установлено соединение с клиентом");
                    NetworkStream stream = tcpClient.GetStream();
                    await AnswerRequestAsync(stream);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Info(ex.Message);
            }
            finally
            {
                server.Stop();
            }




            

        }
    }
}
