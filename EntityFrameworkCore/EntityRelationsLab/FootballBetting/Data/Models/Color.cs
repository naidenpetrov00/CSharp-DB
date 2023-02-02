namespace FootballBetting.Data.Models
{
    public class Color
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Team> PrimaryKitTeams { get; set; } = new HashSet<Team>();  
        public ICollection<Team> SecondaryKitTeams { get; set; } = new HashSet<Team>();
    }
}
