using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace servers
{
    internal class Exceptions
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }

        public static string RouteNotFound()
        {
            var exception = Schemas.ToResponse(false, 0, "Route not found.", null);
            // Chuyển đổi đối tượng thành chuỗi JSON
            return JsonConvert.SerializeObject(exception);
        }
    }
}
