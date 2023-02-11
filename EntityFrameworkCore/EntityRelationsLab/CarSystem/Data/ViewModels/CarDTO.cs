using CarSystem.Data.Models;

namespace CarSystem.Data.ViewModels
{
    public class CarDTO
    {
        public decimal Price { get; set; }

        public string Color { get; set; }

        public string ModelName { get; set; }

        public int ModelYear { get; set; }
    }
}
