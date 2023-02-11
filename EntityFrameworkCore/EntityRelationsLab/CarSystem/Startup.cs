namespace CarSystem
{
    using CarSystem.Data;
    using CarSystem.Data.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using var db = new CarDbContext();

            var car = db.Cars
                .Select(c => new CarDTO()
                {
                    Price = c.Price,
                    Model = $"{c.Model.Name} {c.Model.Year}"
                })
                .ToList();

            //var carDTO = new CarDTO()
            //{
            //    Price = car.Price,
            //    Model = $"{car.Model.Name} {car.Model.Year}"
            //};

            var result = JsonConvert.SerializeObject(car, Formatting.Indented);

            Console.WriteLine(result);
        }
    }
}