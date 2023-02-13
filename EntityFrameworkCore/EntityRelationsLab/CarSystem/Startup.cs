namespace CarSystem
{
    using AutoMapper;
    using CarSystem.Data;
    using Newtonsoft.Json;
    using CarSystem.Data.Models;
    using CarSystem.Data.ViewModels;
    using AutoMapper.QueryableExtensions;
    using AutoMapper.EquivalencyExpression;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using var db = new CarDbContext();

            Mapper.Initialize(cfg =>
            {
                cfg.AddCollectionMappers();
                cfg.CreateMap<Car, CarDto>()
                .ReverseMap();
            });

            //var car = db.Cars
            //    .FirstOrDefault();

            //var carDTO = Mapper.Map<CarDTO>(car);

            //var carDTO = new CarDTO()
            //{
            //    Price = 9000,
            //    Color = "Red",
            //    ModelName = "Corsa",
            //    ModelYear = 1997
            //};

            //var car = Mapper.Map<Car>(carDTO);

            //var carDTO = new CarDTO()
            //{
            //    Price = car.Price,
            //    Model = $"{car.Model.Name} {car.Model.Year}"
            //};

            //var cars = db.Cars
            //    .Where(c => c.Color == "Black")
            //    .ProjectTo<CarDTO>()
            //    .ToList();

            //var cars = new List<Car>()
            //{
            //    new Car()
            //    {
            //        Id = 1,
            //        Price = 25000,
            //        Color = "White"
            //    },
            //    new Car()
            //    {
            //        Id = 2,
            //        Price = 20000,
            //        Color = "Green"
            //    }
            //};

            //var carDtos = new List<CarDTO>()
            //{
            //    new CarDTO()
            //    {
            //        Id = 1,
            //        Price = 25000
            //    },
            //    new CarDTO()
            //    {
            //        Id = 3,
            //        Price = 20000,
            //        Color = "Green"
            //    }
            //};

            //Mapper.Map<List<CarDTO>, List<Car>>(carDtos, cars);

            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Car, CarDto>()
                          .ForMember(
                            dest => dest.ModelName,
                            opt => opt.MapFrom(src => src.Model.Name));
                }
            );

            var car = db.Cars
                .Where(c => c.Color == "Black")
                .Select(c => new CarDto()
                {
                    Price = c.Price
                })
                .FirstOrDefault();

            var mapper = config.CreateMapper();

            var carDto = mapper.Map<Car, CarDto>(car);

            var resultDTO = JsonConvert.SerializeObject(carDto, Formatting.Indented);
            Console.WriteLine(resultDTO);
            var result = JsonConvert.SerializeObject(car, Formatting.Indented);
            Console.WriteLine(result);

        }
    }
}