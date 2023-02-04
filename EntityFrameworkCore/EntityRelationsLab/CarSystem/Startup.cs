namespace CarSystem
{
    using CarSystem.Data;
    using CarSystem.Result;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using var db = new CarDbContext();

            var price = 5000;

            var r = db.Cars
                .Where(c => c.Price > price)
                .Select(c => new
                {
                    FullName = c.Model.Name
                });

            //for situations with too much load

            var query = EF.CompileQuery<CarDbContext, IEnumerable<ResultModel>>(
                db => db.Cars
                 .Where(c => c.Price > price)
                 .Select(c => new ResultModel
                 {
                     FullName = c.Model.Name
                 }));

            var result = query(db);

            Console.WriteLine(result);

            db.SaveChanges();
        }
    }
}