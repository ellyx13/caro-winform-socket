using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace servers.Users
{
    public class Model
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Credits { get; set; }
    }
}
