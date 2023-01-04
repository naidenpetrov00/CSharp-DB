namespace _06.RemoveVillain
{
    using System.Data.SqlClient;

    class Startup
    {
        private static string connectionString =
            "Server=DESKTOP-ERAGAG4\\SQLEXPRESS;" +
            "Database=MinionsDB;" +
            "Integrated Security=true";
        private static SqlConnection connection = new SqlConnection(connectionString);
        private static SqlTransaction transaction;

        static void Main(string[] args)
        {
            var id = int.Parse(Console.ReadLine());

            connection.Open();

            using (connection)
            {
                transaction = connection.BeginTransaction();
                try
                {
                    var command = new SqlCommand();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandText = "SELECT Name FROM Villains WHERE Id = @villainId";
                    command.Parameters.AddWithValue("@villainId", id);

                    var value = command.ExecuteScalar();

                    if (value == null)
                    {
                        throw new ArgumentException("No such villain was found.");
                    }

                    var villianName = (string)value;

                    command.CommandText = @"DELETE FROM MinionsVillains 
                                            WHERE VillainId = @villainId";
                    var minionsDeleted = command.ExecuteNonQuery();

                    command.CommandText = @"DELETE FROM Villains
                                            WHERE Id = @villainId";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine($"{villianName} was deleted.");
                    Console.WriteLine($"{minionsDeleted} minions were released.");
                }
                catch (ArgumentException ane)
                {
                    try
                    {
                        Console.WriteLine(ane.Message);
                        transaction.Rollback();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}