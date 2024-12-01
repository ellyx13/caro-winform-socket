using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace servers.Database
{
    internal class BaseCRUD
    {
        private readonly IMongoCollection<BsonDocument> _collection;


        public BaseCRUD(string connectionString, string DatabaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(DatabaseName);
            _collection = database.GetCollection<BsonDocument>(collectionName);
        }

        // Phương thức Save: Lưu tài liệu vào MongoDB
        public async Task<T> Save<T>(T data)
        {
            // Chuyển đổi đối tượng thành BsonDocument
            var bsonDocument = data.ToBsonDocument();

            // Loại bỏ _id nếu nó là null để MongoDB tự động tạo
            if (bsonDocument.Contains("_id") && bsonDocument["_id"].IsBsonNull)
            {
                bsonDocument.Remove("_id");
            }

            // Chèn tài liệu vào MongoDB
            await _collection.InsertOneAsync(bsonDocument);

            // Lấy ObjectId được MongoDB tạo ra
            var objectId = bsonDocument["_id"].AsObjectId;

            // Gắn ObjectId vào đối tượng ban đầu và trả về
            var dataDocument = data.ToBsonDocument();
            dataDocument["_id"] = objectId;

            return BsonSerializer.Deserialize<T>(dataDocument);
        }

        // Phương thức GetById: Lấy tài liệu dựa trên ObjectId
        public async Task<T> GetById<T>(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
            var result = await _collection.Find(filter).FirstOrDefaultAsync();

            if (result == null)
            {
                // Trả về giá trị mặc định của T
                return default;
            }

            return BsonSerializer.Deserialize<T>(result);
        }

        // Phương thức GetByField: Lấy tài liệu dựa trên giá trị một trường
        public async Task<List<T>> GetByField<T>(string fieldName, string data)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(fieldName, data);
            var results = await _collection.Find(filter).ToListAsync();

            var documents = new List<T>();
            foreach (var document in results)
            {
                documents.Add(BsonSerializer.Deserialize<T>(document));
            }

            return documents;
        }

        // Phương thức UpdateById: Cập nhật tài liệu dựa trên ObjectId
        public async Task<bool> UpdateById<T>(string id, T updatedData)
        {
            // Tạo bộ lọc dựa trên _id
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));

            // Chuyển đối tượng cập nhật thành BsonDocument và loại bỏ _id (nếu có)
            var bsonDocument = updatedData.ToBsonDocument();
            if (bsonDocument.Contains("_id"))
            {
                bsonDocument.Remove("_id"); // Không cho phép cập nhật _id
            }

            // Tạo định nghĩa cập nhật
            var updateDefinition = new BsonDocument("$set", bsonDocument);

            // Thực hiện cập nhật
            var result = await _collection.UpdateOneAsync(filter, updateDefinition);

            // Trả về true nếu ít nhất một tài liệu được cập nhật
            return result.ModifiedCount > 0;
        }

        // Phương thức DeleteById: Xóa tài liệu dựa trên ObjectId
        public async Task<bool> DeleteById(string id)
        {
            // Tạo bộ lọc dựa trên `_id`
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));

            // Thực hiện xóa tài liệu
            var result = await _collection.DeleteOneAsync(filter);

            // Trả về `true` nếu ít nhất một tài liệu được xóa
            return result.DeletedCount > 0;
        }
    }
}
