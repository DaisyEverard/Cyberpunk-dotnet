using cyberpunk_dotnet.Data.Interfaces;
using cyberpunk_dotnet.Data.Mongo.Models;
using cyberpunk_dotnet.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cyberpunk_dotnet.Data.Mongo
{
    public class Mongo : ICharacterRepository
    {
        MongoClient _client;
        IMongoDatabase _database;
        public Mongo() {
            _client = new MongoClient("mongodb://localhost:27017/");//Environment.GetEnvironmentVariable("MONGODB_URI"));
            _database = _client.GetDatabase("cyberpunk-red");
        }

        public async Task<Character> GetByID(string id)
        {
            var _collection = _database.GetCollection<MongoCharacter>("characters");
            var mongoResponse = await _collection.Find(document => document.id == id).FirstOrDefaultAsync();
            return mongoResponse.MapToCharacterResponse();
        }

        public async Task<Character> GetByName(string name)
        {
            var _collection = _database.GetCollection<MongoCharacter>("characters");
            var mongoResponse = await _collection.Find(document => document.name == name).FirstOrDefaultAsync();
            return mongoResponse.MapToCharacterResponse();
        }

        public async Task<EditCharacterResponse> Create(NewCharacterRequest request)
        { try
            {

                var newCharacter = new MongoCharacter
                {
                    id = null,
                    name = request.name,
                    role = request.role,
                    stats = request.stats,
                    hp = request.hp,
                    humanity = request.humanity,
                    currentSkills = request.currentSkills,
                    currentEffects = request.currentEffects
                };
                var _collection = _database.GetCollection<MongoCharacter>("characters");
                if (newCharacter != null && _collection != null)
                {
                    await _collection.InsertOneAsync(newCharacter);
                }

                return new EditCharacterResponse
                {
                    id = newCharacter?.id,
                    success = true,
                    error = null
                };
            } catch (Exception e)
            {
                return new EditCharacterResponse
                {
                    id = null,
                    success = false,
                    error = e.ToString()
                };
            }
        }


        public async Task<EditCharacterResponse> Delete(string id) {
            try
            {
                var _collection = _database.GetCollection<MongoCharacter>("characters");
                var mongoResponse = await _collection.DeleteOneAsync(document => document.id == id);

                var response = new EditCharacterResponse
                {
                    id = id,
                    success = true,
                    error = null
                };

                if (mongoResponse.DeletedCount == 0)
                {
                    response = new EditCharacterResponse
                    {
                        id = id,
                        success = false,
                        error = "Delete Count == 0"
                    };
                }

                return response;
            }
            catch (Exception e) {
                return new EditCharacterResponse
                {
                    id = id,
                    success = false,
                    error = e.ToString()
                };
            }
        }

        public async Task<EditCharacterResponse> Update(Character updatedCharacter)
        {
            try {
                var _collection = _database.GetCollection<MongoCharacter>("characters");

                var newCharacter = new MongoCharacter
                {
                    id = updatedCharacter.id,
                    name = updatedCharacter.name,
                    role = updatedCharacter.role,
                    stats =updatedCharacter.stats,
                    hp = updatedCharacter.hp,
                    humanity = updatedCharacter.humanity,
                    currentSkills = updatedCharacter.currentSkills,
                    currentEffects = updatedCharacter.currentEffects
                };

                if (newCharacter != null && _collection != null)
                {
                    await _collection.ReplaceOneAsync(document => document.id == newCharacter.id, newCharacter);
                }

                return new EditCharacterResponse
                {
                    id = updatedCharacter.id,
                    success = true,
                    error = null
                };
            } catch (Exception e)
            {
                return new EditCharacterResponse
                {
                    id = updatedCharacter.id,
                    success = false,
                    error = e.ToString()
                };
            }
        }

        public async Task<List<NameAndID>> GetAllNamesAndIDs()
        { var _collection = _database.GetCollection<MongoCharacter>("characters");
        
            var projection = Builders<MongoCharacter>.Projection.Expression(document => new { document.id, document.name });
            var documents = await _collection.Find(_ => true).Project(projection).ToListAsync();

            var namesAndIDs = new List<NameAndID>();
            foreach (var doc in documents)
            {
                Console.WriteLine(doc.ToJson());
                namesAndIDs.Add(new NameAndID { name = doc.name, id = doc.id });
            }
            return namesAndIDs;
        }
        }
}
