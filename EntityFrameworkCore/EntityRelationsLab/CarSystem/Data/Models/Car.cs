namespace CarSystem.Data.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataValidations.Car;

    public class Car
    {
        public int Id { get; set; }

        public DateTime ProductionDate { get; set; }

        [Required]
        [MaxLength(VinLength)]
        public string Vin { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MaxLength(ColorMax)]
        public string Color { get; set; }

        public int ModelId { get; set; }
        [JsonIgnore]
        public Model Model { get; set; }

        public ICollection<CarPurchase> Owners { get; set; } = new HashSet<CarPurchase>();
    }
}
