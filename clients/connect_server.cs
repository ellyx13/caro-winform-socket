using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clients
{
    public class connect_server
    {
        private readonly string serverIP;
        private readonly int serverPort;
        private TcpClient client;
        private NetworkStream stream;
        private volatile bool isReceiving;

        public connect_server()
        {
            serverIP = "172.17.48.190";
            serverPort = 12345;
        }

        public connect_server(string serverIP, int serverPort)
        {
            this.serverIP = serverIP;
            this.serverPort = serverPort;
        }


        public bool Connect()
        {
            try
            {
                client = new TcpClient(serverIP, serverPort);
                stream = client.GetStream();
                Console.WriteLine($"Connected to server at {serverIP}:{serverPort}");
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect to server: {ex.Message}");
                return false;
            }
        }

        public void StartReceiving()
        {
            if (client == null || !client.Connected)
            {
                Console.WriteLine("Not connected to server.");
                return;
            }

            isReceiving = true;
            Thread receiveThread = new Thread(() =>
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    while (isReceiving)
                    {
                        if (stream.DataAvailable)
                        {
                            int bytesRead = stream.Read(buffer, 0, buffer.Length);
                            if (bytesRead == 0) break;

                            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            Console.WriteLine($"Received: {message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error receiving data: {ex.Message}");
                }
                finally
                {
                    Disconnect();
                }
            })
            {
                IsBackground = true // Đảm bảo thread không giữ ứng dụng
            };
            receiveThread.Start();
        }


        // Gửi tin nhắn tới server
        public void SendMessage(string message)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    Console.WriteLine("Not connected to server.");
                    return;
                }

                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine($"Sent: {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send message: {ex.Message}");
            }
        }

        // Ngắt kết nối
        public void Disconnect()
        {
            try
            {
                isReceiving = false; // Dừng luồng nhận
                stream?.Close();
                client?.Close();
                Console.WriteLine("Disconnected from server.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error disconnecting: {ex.Message}");
            }
        }

    }
}
