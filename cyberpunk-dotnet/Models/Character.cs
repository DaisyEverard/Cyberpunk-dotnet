using System.Security.Cryptography.X509Certificates;

namespace cyberpunk_dotnet.Models
{
    public class Character
    {
        public string? id {  get; set; }
        public required string name { get; set; }
        public required string role { get; set; }
        public required List<Stat> stats { get; set; }
        public required Int32 hp { get; set; }
        public required Int32 humanity { get; set; }
        public required List<Skill> currentSkills { get; set; } 
        public required List<Effect> currentEffects { get; set; }
    }
}
