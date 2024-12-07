using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace clients
{
    public class Schemas
    {
        public class Request
        {
            public string UserId { get; set; }
            public string Route { get; set; }
            public Dictionary<string, object> Data { get; set; }
        }

        public class Response
        {
            public bool Success { get; set; }
            public int Code { get; set; }

            public string Message { get; set; }
            public Dictionary<string, object> Data { get; set; }
        }

        public static Response ToDictionary(string response)
        {
            return JsonConvert.DeserializeObject<Response>(response);
        }

        public static string ToRequest(string userId, string route, Dictionary<string, object> data)
        {
            var request = new Request
            {
                UserId = userId,
                Route = route,
                Data = data
            };

            return JsonConvert.SerializeObject(request);
        }


    }
}
