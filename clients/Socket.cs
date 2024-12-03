using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clients
{
    public class SocketClient
    {
        private readonly string _serverIp;
        private readonly int _serverPort;
        private TcpClient _client;
        private NetworkStream _stream;

        public string ClientId { get; private set; }

        // Constructor
        public SocketClient(string serverIp, int serverPort)
        {
            _serverIp = serverIp;
            _serverPort = serverPort;
        }

        // Kết nối tới server
        public async Task<bool> ConnectAsync(string clientId)
        {
            try
            {
                ClientId = clientId;
                _client = new TcpClient();
                await _client.ConnectAsync(_serverIp, _serverPort);
                _stream = _client.GetStream();

                // Gửi ID tới server
                var idBytes = Encoding.UTF8.GetBytes(clientId);
                await _stream.WriteAsync(idBytes, 0, idBytes.Length);

                Console.WriteLine($"Connected to server as {clientId}.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect: {ex.Message}");
                return false;
            }
        }

        // Gửi dữ liệu tới server
        public async Task SendAsync(string message)
        {
            try
            {
                if (_stream == null) throw new InvalidOperationException("Not connected to server.");
                var data = Encoding.UTF8.GetBytes(message);
                await _stream.WriteAsync(data, 0, data.Length);
                Console.WriteLine($"Sent: {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send message: {ex.Message}");
            }
        }

        // Nhận dữ liệu từ server
        public async Task<string> ReceiveAsync()
        {
            try
            {
                if (_stream == null) throw new InvalidOperationException("Not connected to server.");
                var buffer = new byte[1024];
                int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                var response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received: {response}");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to receive message: {ex.Message}");
                return null;
            }
        }

        // Ngắt kết nối
        public void Disconnect()
        {
            try
            {
                _stream?.Close();
                _client?.Close();
                Console.WriteLine("Disconnected from server.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to disconnect: {ex.Message}");
            }
        }
    }

}
