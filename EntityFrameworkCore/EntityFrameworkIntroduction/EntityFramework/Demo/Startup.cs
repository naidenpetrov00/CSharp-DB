namespace Demo
{
    using Demo.Data;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var town = new Town
                {
                    Name = "Pernik"
                };

                db.Add(town);

                db.SaveChanges();
            }
        }
    }
}