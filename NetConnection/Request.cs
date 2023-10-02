using System.Collections.Generic;
using System.Text.Json;

namespace NetConnection
{
    public class Request
    {
        public string Action { get; }
        public List<string> Content { get; set; }
        [System.Text.Json.Serialization.JsonConstructor]
        public Request(string action, List<string> content)
        {
            Action = action;
            Content = content;
        }

        public Request(string action, string content)
        {
            Action = action;
            Content = new List<string>() { content };
        }

        public string GetJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public static Request GetRequest(string json)
        {
            return JsonSerializer.Deserialize<Request>(json);
        }
    }
}
