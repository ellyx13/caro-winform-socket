using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json;

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

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                { "Id", Id },
                { "Name", Name },
                { "Code", Code },
                { "Host", Host },
                { "Guest", Guest },
                { "IsHostWin", IsHostWin },
            };
        }
    }
}
