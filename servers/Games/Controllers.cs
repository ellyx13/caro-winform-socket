using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using servers.Database;
using servers.Users;

namespace servers.Games
{
    internal class GameControllers
    {
        private readonly BaseCRUD crud;
        private readonly UserControllers userControllers;

        public GameControllers()
        {
            crud = new BaseCRUD(Config.DatabaseUrl, Config.DatabaseName, "games");
            userControllers = new UserControllers();
        }

        // Lấy game theo ID
        public async Task<GameModel> GetById(string id)
        {
            var game = await crud.GetById<GameModel>(id);
            return game;
        }

        // Lấy game theo trường cụ thể
        public async Task<List<GameModel>> GetByField(string fieldName, string data)
        {
            var games = await crud.GetByField<GameModel>(fieldName, data);
            return games;
        }

        // Phương thức UpdateById
        public async Task<bool> UpdateById(string id, GameModel updatedData)
        {
            // Không cho phép cập nhật _id
            updatedData.Id = null;

            // Thực hiện cập nhật
            var isUpdated = await crud.UpdateById(id, updatedData);

            return isUpdated;
        }

        // Phương thức tạo mã trò chơi gồm 4 ký tự số
        private async Task<string> GenerateUniqueCodeGame()
        {
            var random = new Random();
            string code;
            List<GameModel> result;
            do
            {
                code = random.Next(1000, 10000).ToString();
                result = await crud.GetByField<GameModel>("Code", code);
            } while (result.Count != 0);

            return code;
        }


        public async Task<GameModel> Save(string name, string host)
        {
            // Tạo đối tượng game
            var game = new GameModel
            {
                Name = name,
                Host = host,
                Status = "waiting",
                Code = await GenerateUniqueCodeGame()
            };

            // Lưu game vào cơ sở dữ liệu
            var result = await crud.Save(game);

            return result;
        }

        // Tham gia game
        public async Task<string> JoinGame(string gameCode, string guest)
        {
            // Lấy game theo mã trò chơi (gameCode)
            var games = await crud.GetByField<GameModel>("Code", gameCode);
            if (games.Count == 0)
            {
                return GameExceptions.GameNotFound();
            }

            var game = games[0];

            if (game.Status == "playing")
            {
                return GameExceptions.GameIsPlaying();
            }

            if (game.Status == "end")
            {
                return GameExceptions.GameIsEnd();
            }

            // Cập nhật Host
            game.Guest = guest;
            game.Status = "playing";

            // Lưu thay đổi
            await crud.UpdateById(game.Id, game);

            // Trừ tiền Guest
            await userControllers.MinusMoney(guest);

            var gameUpdated = await crud.GetById<GameModel>(game.Id);
            var gameData = gameUpdated.ToDictionary();

            return Schemas.ToResponse(true, 22, "Join game successed.", gameData);
        }

        public async Task<string> CreateGame(string gameName, string HostId)
        {
            // Trừ tiền Host
            await userControllers.MinusMoney(HostId);

            var games = await Save(gameName, HostId);
            var gameData = games.ToDictionary();

            return Schemas.ToResponse(true, 23, "Create game successed.", gameData);
        }

        // Phương thức cập nhật người thắng
        public async Task<string> SetWinner(string gameId, string winner)
        {
            // Lấy thông tin trò chơi theo ID
            var game = await crud.GetById<GameModel>(gameId);
            game.Status = "end";

            if (game.Host == winner)
            {
                game.IsHostWin = true;
            }
            else
            {
                game.IsHostWin = false;

            }

            await userControllers.PlusMoneyForWinner(winner);

            // Lưu thay đổi
            await crud.UpdateById(game.Id, game);
            var gameUpdated = await crud.GetById<GameModel>(gameId);
            var gameData = gameUpdated.ToDictionary();
            return Schemas.ToResponse(true, 26, winner + " is winner.", gameData);
        }

        public string MakeMove(string gameId, string userId, int x, int y)
        {
            return Schemas.ToResponse(true, 26, "Make move successed.", null);
        }
    }
}
