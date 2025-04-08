namespace cyberpunk_dotnet.Models
{

    public class Skill
    {
        public required string name { get; set; }
        public required int level { get; set; }
        public required bool has_options { get; set; }
        public required string stat_type { get; set; }
        public List<Option>? options { get; set; }
    }

    public class Option
    {
        public required string name { get; set; }
        public required int level { get; set; }
    }
}