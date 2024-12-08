using servers.Users;
using System;
using System.Threading.Tasks;

namespace servers
{

    public static class Logger
    {
        private const int EventTypeWidth = 10;
        private static UserControllers _userControllers = new UserControllers();

        // Định dạng căn trái event type
        private static string FormatEventType(string eventType)
        {
            return eventType.PadRight(EventTypeWidth);
        }

        // In thông tin kết nối
        public static void Connection(string message, string userFullName = null)
        {
            PrintLog("CONNECT", message, userFullName);
        }

        // In log khi nhận dữ liệu từ client
        public static void Received(string message, string userFullName = null)
        {
            PrintLog("RECEIVED", message, userFullName);
        }

        // In log khi gửi phản hồi tới client
        public static void Response(string message, string userFullName = null)
        {
            PrintLog("RESPONSE", message, userFullName);
        }

        // In log khi có lỗi xảy ra
        public static void Error(string message, Exception ex = null, string userFullName = null)
        {
            var errorDetails = ex != null ? $"{message}. Exception: {ex.Message}" : message;
            PrintLog("ERROR", errorDetails, userFullName);
        }

        public static void Info(string message, string userFullName = null)
        {
            PrintLog("INFO", message, userFullName);
        }

        // In log cho các sự kiện chat
        public static void Chat(string senderFullName, string receiverFullName, string message)
        {
            var chatLog = $"To {receiverFullName}: {message}";
            PrintLog("CHAT", chatLog, senderFullName);
        }

        // Hàm chung để in log với format
        private static void PrintLog(string eventType, string message, string userFullName = null)
        {
            var time = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"); // Thời gian hiện tại
            string prefixUser = userFullName != null ? $"User {userFullName}: " : "";
            Console.WriteLine($"{time} | {FormatEventType(eventType)} | {prefixUser}{message}");
        }
    }

}
