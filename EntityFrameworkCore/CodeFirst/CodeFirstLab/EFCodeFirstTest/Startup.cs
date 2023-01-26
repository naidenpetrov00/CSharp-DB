using System.Diagnostics.Tracing;

namespace EFCodeFirstTest
{
    using EFCodeFirstTest.Data;
    using EFCodeFirstTest.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using var db = new StudentsDbContext();

            db.Database.Migrate();
        }
    }
}
//1. Create models - ek. Students
//2. Primary key - Id
//3. Add Columns and their requirments
//4. Add DbContext + DbSet
//5. OnConfiguring - connection string
//6. OnModelCreating - models
//7. Realationship - ForeignKey TownId + Property Town Town + collection in other model
//8. Add-Migration
//9. db.Database.Migrate()