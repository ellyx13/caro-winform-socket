using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using servers.Database;
namespace servers.Users
{
    internal class UserControlers
    {
        private readonly BaseCRUD crud;

        public UserControlers()
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
                Credits = 100_000 // Mặc định là 100.000
            };

            // Lưu user vào cơ sở dữ liệu
            var result = await crud.Save(user);

            return result;
        }
    }
}
