﻿namespace FootballBetting.Data.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public Prediction Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
