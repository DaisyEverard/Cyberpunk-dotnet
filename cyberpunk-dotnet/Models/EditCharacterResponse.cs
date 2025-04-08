using System.Security.Cryptography.X509Certificates;

namespace cyberpunk_dotnet.Models
{
    public class EditCharacterResponse
    {
        public string? id { get; set; }
        public bool success { get; set; }
        public string? error {get; set; } 
    }
}
