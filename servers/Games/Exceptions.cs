using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace servers.Games
{
    internal class GameExceptions
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }

        public static string GameNotFound()
        {
            var exception = new GameExceptions
            {
                Success = false,
                Code = 20,
                Message = "Game not found."
            };

            // Chuyển đổi đối tượng thành chuỗi JSON
            return JsonConvert.SerializeObject(exception);
        }

        public static string GameIsEnd()
        {
            var exception = new GameExceptions
            {
                Success = false,
                Code = 21,
                Message = "Game is end."
            };

            // Chuyển đổi đối tượng thành chuỗi JSON
            return JsonConvert.SerializeObject(exception);
        }

    }
}
