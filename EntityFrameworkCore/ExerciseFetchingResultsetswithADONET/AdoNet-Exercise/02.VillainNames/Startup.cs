using System.Data.SqlClient;

namespace _02.VillainNames
{
    class Startup
    {
        private static string conectionString =
            "Server=DESKTOP-ERAGAG4\\SQLEXPRESS;" +
            "Database=MinionsDB;" +
            "Integrated Security=true";
        private static SqlConnection connection = new SqlConnection(conectionString);

        static void Main(string[] args)
        {
            connection.Open();

            using (connection)
            {
                var queryText = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                      FROM Villains AS v 
                                      JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                  GROUP BY v.Id, v.Name 
                                    HAVING COUNT(mv.VillainId) > 3 
                                  ORDER BY COUNT(mv.VillainId)";
                var command = new SqlCommand(queryText, connection);

                try
                {
                    var reader = command.ExecuteReader();
                     
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was problem processing you request!");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}