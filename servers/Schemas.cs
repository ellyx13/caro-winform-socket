using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Newtonsoft.Json;
using Sprache;


namespace servers
{
    public class Schemas
    {
        public class Request
        {
            public string UserId { get; set; }
            public string Route { get; set; }
            public Dictionary<string, string> Data { get; set; }
        }

        public class Response
        {
            public bool Success { get; set; }
            public int Code { get; set; }
            public string Message { get; set; }
            public Dictionary<string, object> Data { get; set; }
        }

        public static string ToResponse(bool success, int code, string message, Dictionary<string, object> data)
        {
            var response = new Response
            {
                Success = success,
                Code = code,
                Message = message,
                Data = data
            };
            // Do nullable chỉ hỗ trợ cs 8.0, nên phải set Data là null:null nếu Data là null,
            // để clients controllers có thể parse json string thành Response
            if (response.Data is null)
            {
                response.Data = new Dictionary<string, object>{
                    { "null", "null" },
                    { "null", "null" }
                }; ;
            }
            return JsonConvert.SerializeObject(response);
        }

    }
}
