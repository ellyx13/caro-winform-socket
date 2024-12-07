using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using servers.Database;

namespace servers.Users
{
    internal class UserControllers
    {
        private readonly BaseCRUD crud;

        public UserControllers()
        {
            crud = new BaseCRUD(Config.DatabaseUrl, Config.DatabaseName, "users");
        }

        // Lấy user theo ID
        public async Task<UsersModel> GetById(string id)
        {
            var user = await crud.GetById<UsersModel>(id);
            return user;
        }

        // Lấy user theo trường cụ thể
        public async Task<List<UsersModel>> GetByField(string fieldName, string data)
        {
            var users = await crud.GetByField<UsersModel>(fieldName, data);
            return users;
        }

        // Phương thức UpdateById
        public async Task<bool> UpdateById(string id, UsersModel updatedData)
        {
            // Không cho phép cập nhật _id
            updatedData.Id = null;

            // Thực hiện cập nhật
            var isUpdated = await crud.UpdateById(id, updatedData);

            return isUpdated;
        }

        public async Task<UsersModel> Save(string fullname, string email, string password)
        {
            // Tạo đối tượng user
            var user = new UsersModel
            {
                Name = fullname,
                Email = email,
                Password = password,
                Credits = 100000 // Mặc định là 100.000
            };

            // Lưu user vào cơ sở dữ liệu
            var result = await crud.Save(user);

            return result;
        }

        public async Task<bool> MinusMoney(string userId)
        {
            var user = await GetById(userId);
            user.Credits = user.Credits - 10000;
            return await UpdateById(userId, user);
        }

        public async Task<bool> PlusMoneyForWinner(string userId)
        {
            var user = await GetById(userId);
            user.Credits = user.Credits + 10000;
            return await UpdateById(userId, user);
        }

        // Hàm xử lý đăng ký người dùng
        public async Task<string> RegisterUser(Dictionary<string, string> data)
        {
            string fullname = data.ContainsKey("fullname") ? data["fullname"] : null;
            string username = data.ContainsKey("username") ? data["username"] : null;
            string password = data.ContainsKey("password") ? data["password"] : null;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return UserExceptions.MissingField();
            }

            List<UsersModel> users = await GetByField("Email", username);
            if (users.Any())
            {
                return UserExceptions.UserExist();
            }

            UsersModel user = await Save(fullname, username, password);
            var userData = user.ToDictionary();
            return Schemas.ToResponse(true, 12, "Register successed.", userData);
        }

        public async Task<string> LoginUser(Dictionary<string, string> data)
        {
            string username = data.ContainsKey("username") ? data["username"] : null;
            string password = data.ContainsKey("password") ? data["password"] : null;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return UserExceptions.MissingField();
            }

            List<UsersModel> users = await GetByField("Email", username);
            if (!users.Any())
            {
                return UserExceptions.UserNotFound();
            }

            UsersModel user = users[0];
            var userData = user.ToDictionary();
            return Schemas.ToResponse(true, 14, "Login successed.", userData);
        }
    }
}
