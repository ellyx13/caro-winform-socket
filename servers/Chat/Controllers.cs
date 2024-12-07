using DnsClient.Internal;
using servers.Database;
using servers.Games;
using servers.Users;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servers.Chat
{
    internal class ChatControllers
    {
        private readonly UserControllers userControllers;
        private readonly GameControllers gameControllers;
        private readonly BaseCRUD crud;

        public ChatControllers()
        {
            crud = new BaseCRUD(Config.DatabaseUrl, Config.DatabaseName, "chats");
            userControllers = new UserControllers();
            gameControllers = new GameControllers();
        }

        public async Task<ChatModel> Save(string gameId, string senderId, string receiverId, string message)
        {
            var chat = new ChatModel
            {
                GameId = gameId,
                SenderId = senderId,
                ReceiverId = receiverId,
                Message = message,
                CreatedAt = DateTime.UtcNow
            };

            var result = await crud.Save(chat);
            return result;
        }

        public async Task<string> GetReceiverId(string userId, string gameId)
        {
            var game = await gameControllers.GetById(gameId);

            if (userId == game.Host)
            {
                return game.Guest;
            }
            return game.Host;
        }
    }
}
