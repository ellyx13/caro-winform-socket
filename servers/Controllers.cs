using servers.Games;
using servers.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace servers
{
    internal class ServerControllers
    {
        private readonly UserControllers _userController;
        private readonly GameControllers _gameController;

        public ServerControllers()
        {
            _userController = new UserControllers();
            _gameController = new GameControllers();
        }

        // Xử lý request từ client
        public async Task<string> HandleRequest(string requestJson)
        {
            // Parse dữ liệu JSON từ client
            var request = JsonConvert.DeserializeObject<Schemas.Request>(requestJson);


            // Xử lý route và điều hướng đến controller tương ứng
            switch (request.Route)
            {
                case "users/register":
                    return await _userController.RegisterUser(request.Data);
                default:
                    return Exceptions.RouteNotFound();
            }
        }
    }

}
