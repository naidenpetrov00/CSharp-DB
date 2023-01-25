namespace EFCodeFirstTest
{
    using EFCodeFirstTest.Data;
    using EFCodeFirstTest.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    public class Startup
    {
        public static void Main(string[] args)
        {
            using var db = new StudentsDbContext();

            db.Database.Migrate();

            var result= db.Students
                .Select(s => new
                {
                    FullName = s.FirstName + s.LastName,
                    TownName = s.Town.Name
                })
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}