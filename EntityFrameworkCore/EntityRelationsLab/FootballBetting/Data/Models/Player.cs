﻿namespace FootballBetting.Data.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SquadNumber { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public bool IsInjured { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new HashSet<PlayerStatistic>();
    }
}
