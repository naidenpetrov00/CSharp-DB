namespace CarSystem
{
    using CarSystem.Data;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using var db = new CarDbContext();

            var price = 5000;

            db.Cars
                .Where(c => c.Price > price);

            var result = db.Cars
                .FromSqlInterpolated($"SELECT * FROM Cars WHERE Price > {price}")
                .ToList();

            Console.WriteLine(result);

            db.SaveChanges();
        }
    }
}