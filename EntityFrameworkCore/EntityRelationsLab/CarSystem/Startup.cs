namespace CarSystem
{
    using CarSystem.Data;
    using CarSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query.Internal;
    using System.ComponentModel.DataAnnotations;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using var db = new CarDbContext();

            db.Database.Migrate();

            var model = new Model
            {
                Modification = "500",
                Name = "CL",
                Year = 3000
            };

            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();

            Validator.ValidateObject(model, validationContext, true);

            db.SaveChanges();
        }
    }
}