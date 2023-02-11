namespace CarSystem
{
    using AutoMapper;
    using CarSystem.Data;
    using CarSystem.Data.Models;
    using CarSystem.Data.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, CarDTO>()
                .ReverseMap();

            });

            using var db = new CarDbContext();

            //var car = db.Cars
            //    .Include(c => c.Model)
            //    .FirstOrDefault();

            //var carDTO = Mapper.Map<CarDTO>(car);

            var carDTO = new CarDTO()
            {
                Price = 9000,
                Color = "Red",
                ModelName = "Corsa",
                ModelYear = 1997
            };

            var car = Mapper.Map<Car>(carDTO);

            ////var carDTO = new CarDTO()
            ////{
            ////    Price = car.Price,
            ////    Model = $"{car.Model.Name} {car.Model.Year}"
            ////};

            var result = JsonConvert.SerializeObject(car, Formatting.Indented);
            Console.WriteLine(result);
            var resultDTO = JsonConvert.SerializeObject(carDTO, Formatting.Indented);
            Console.WriteLine(resultDTO);

        }
    }
}