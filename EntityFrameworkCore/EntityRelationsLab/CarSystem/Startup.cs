namespace CarSystem
{
    using CarSystem.Data;
    using CarSystem.Data.Models;
    using CarSystem.Result;
    using Microsoft.EntityFrameworkCore;
    using Z.EntityFramework.Plus;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using var db = new CarDbContext();

            using var data = new CarDbContext();

            // bulk delete
            data.Cars
                .Where(c => c.Price > 10000)
                .Delete();

            // bulk update
            data.Cars
                .Where(c => c.Price < 20000)
                .Update(c => new Car
                {
                    Price = c.Price * 1.2m
                });

            var car = data.Cars
                .FirstOrDefault(c => c.Id == 1);

             

            db.SaveChanges();
        }
    }
}