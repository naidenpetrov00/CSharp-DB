namespace _03.MinionNames
{
    using System.Data.SqlClient;

    class Startup
    {
        private static string connectionString =
            "Server=DESKTOP-ERAGAG4\\SQLEXPRESS;" +
            "Database=MinionsDB;" +
            "Integrated Security=true";
        private static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            var id = int.Parse(Console.ReadLine());

            connection.Open();

            using (connection)
            {
                var querryString = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                     FROM MinionsVillains AS mv
                                     JOIN Minions As m ON mv.MinionId = m.Id
                                     WHERE mv.VillainId = @Id
                                     ORDER BY m.Name";

                try
                {
                    var command = new SqlCommand(querryString, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was problem with executing your request!");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}