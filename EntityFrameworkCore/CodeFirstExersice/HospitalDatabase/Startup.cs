using HospitalDatabase.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalDatabase
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            using var db = new HospitalDbContext();

            db.Database.Migrate();
        }
    }
}