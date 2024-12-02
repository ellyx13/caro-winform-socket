using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace servers.Games
{
    public class GameModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Host { get; set; }
        public string Guest { get; set; } = null;
        public bool? IsHostWin { get; set; } = null;
    }
}
