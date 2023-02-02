namespace FootballBetting.Data.Models
{
    public class Position
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
