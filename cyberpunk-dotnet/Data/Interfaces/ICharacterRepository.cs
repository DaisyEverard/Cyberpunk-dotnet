using System.Security.Cryptography.X509Certificates;
using cyberpunk_dotnet.Models;

namespace cyberpunk_dotnet.Data.Interfaces
{
    public interface ICharacterRepository
    {
        public Task<Character> GetByID(string id);
        public Task<Character> GetByName(string name);

        public Task<List<NameAndID>> GetAllNamesAndIDs();

        public Task<EditCharacterResponse> Update(Character updatedCharacter);
        public Task<EditCharacterResponse> Delete(string id);

        public Task<EditCharacterResponse> Create(NewCharacterRequest newCharacter);
    }
}
