using System.Security.Cryptography.X509Certificates;
using cyberpunk_dotnet.Data.Interfaces;
using cyberpunk_dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace cyberpunk_dotnet.Controllers
{
    [ApiController]
    [Route("character")]
    public class CharacterController : ControllerBase
    {
        public ICharacterRepository _database;

        public CharacterController(ICharacterRepository database)
        {
            _database = database;
        }

        [HttpGet]
        [Route("id/{id}")]
        public async Task<Character> GetByID(string id)
        {
            var Response = await _database.GetByID(id);

            return Response;
        }

        [HttpGet]
        [Route("name/{name}")]
        public async Task<Character> GetByName(string name)
        {
            var Response = await _database.GetByName(name);
            return Response;
        }

        [HttpPost]
        [Route("new")]
        public async Task<EditCharacterResponse> CreateNew([FromBody] NewCharacterRequest request) 
        {
            var Response = await _database.Create(request);
            return Response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<EditCharacterResponse> Delete(string id
            )
        {
            var Response = await _database.Delete(id);
            return Response;
        }

        [HttpPut]
        [Route("update")]
        public async Task<EditCharacterResponse> Update([FromBody] Character updatedCharacter)
        {
            var Response = await _database.Update(updatedCharacter);
            return Response;
        }

        [HttpGet]
        [Route("names_and_ids")]
        public async Task<List<NameAndID>> GetNamesAndIDs()
        {
            var Response = await _database.GetAllNamesAndIDs();
            return Response;
        }
    }
}
