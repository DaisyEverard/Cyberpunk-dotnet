using cyberpunk_dotnet.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace cyberpunk_dotnet.Data.Mongo.Models
{
    public class MongoCharacter 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public required string name { get; set; }
        public required string role { get; set; }
        public required List<Stat> stats { get; set; }
        public required Int32 hp { get; set; }
        public required Int32 humanity { get; set; }
        public required List<Skill> currentSkills { get; set; }
        public required List<Effect> currentEffects { get; set; }

        public Character MapToCharacterResponse()
        {
            return new Character 
            { 
                id = id,
                name = name,
                role = role, 
                stats = stats, 
                hp = hp, 
                humanity = 
                humanity, 
                currentSkills = currentSkills,
                currentEffects = currentEffects
            };
        }
    }
}
