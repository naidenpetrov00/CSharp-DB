namespace CatsDbExample
{
    using CatsDbExample.models;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new CatsDbContext())
            {
                db.Database.EnsureCreated();

                db.Cats.Add(new Cat
                {
                    Name = "A",
                    Age = 1,
                    Color = "Black",
                    Owner = new Owner
                    {
                        Name = "Bai Ivan"
                    }
                });
                db.SaveChanges();
            }
        }
    }
}