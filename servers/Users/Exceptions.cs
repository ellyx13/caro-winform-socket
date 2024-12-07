using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace servers.Users
{
    internal class UserExceptions
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }

        public static string MissingField()
        {
            var exception = new UserExceptions
            {
                Success = false,
                Code = 10,
                Message = "Missing required fields."
            };

            // Chuyển đổi đối tượng thành chuỗi JSON
            return JsonConvert.SerializeObject(exception);
        }

        public static string UserExist()
        {
            var exception = new UserExceptions
            {
                Success = false,
                Code = 11,
                Message = "User already exists."
            };

            return JsonConvert.SerializeObject(exception);
        }

        public static string UserNotFound()
        {
            var exception = new UserExceptions
            {
                Success = false,
                Code = 13,
                Message = "User not found."
            };

            return JsonConvert.SerializeObject(exception);
        }

        public static string AuthenFailed()
        {
            var exception = new UserExceptions
            {
                Success = false,
                Code = 15,
                Message = "Authentication failed."
            };

            return JsonConvert.SerializeObject(exception);
        }
    }
}
