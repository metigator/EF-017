namespace C02.SqlQueryParameter.Entities
{
    public class Participant : Entity
    {
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string FullName => $"{FName} {LName}";

        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
