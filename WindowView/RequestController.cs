using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Shapes;
using NetConnection;

namespace Client
{
    public class RequestController
    {
		private readonly TcpClient tcpClient;
		private readonly NetworkStream stream;

		public RequestController(string ip, int port)
		{
			tcpClient = new TcpClient();
			tcpClient.Connect(ip, port);
			stream = tcpClient.GetStream();
		}

		public Request SendRequest(Request request)
		{
			List<byte> data = new List<byte>();
			stream.Write(Encoding.Unicode.GetBytes(request.GetJson()));
			do
			{
				data.Add((byte)stream.ReadByte());
			}
			while (stream.DataAvailable);
			string json = Encoding.Unicode.GetString(data.ToArray());
			return Request.GetRequest(json);
		}
		public bool SetAndCheckPath(string path)
        {
			Request answer = SendRequest(new Request("SetAndCheckPath", path));
			return (answer.Content[0] == "True");
        }

		public bool SetModelType(string modeltype)
		{
            Request answer = SendRequest(new Request("SetModelType", modeltype));
            return (answer.Content[0] == "True");
        }
		public ObservableCollection<ProductData> GetFullData()
        {
			Request answer = SendRequest(new Request("GetFullData", ""));
			ObservableCollection<ProductData> list = new();
			foreach (string dataFields in answer.Content)
			{
				list.Add(ProductData.ParseFieldsToProduct(dataFields.Split(';').ToList()));
			}
			return list;
		}
		public string GetLineByNumber(int position)
        {
			Request answer = SendRequest(new Request("GetLineByNumber", position.ToString()));
			return answer.Content[0];
		}

		public void SaveNewData(List<string> productsData, int pos)
        {
			productsData.Add(pos.ToString());
			SendRequest(new Request("SaveNewData", productsData));
		}

		public bool DeleteData(int position)
        {
			Request answer = SendRequest(new Request("DeleteData", position.ToString()));
			return (answer.Content[0] == "True");
		}

		public void Shutdown()
        {
			SendRequest(new Request("Shutdown", ""));
		}
		~RequestController()
		{
			stream.Dispose();
			tcpClient.Close();
		}
	}
}
