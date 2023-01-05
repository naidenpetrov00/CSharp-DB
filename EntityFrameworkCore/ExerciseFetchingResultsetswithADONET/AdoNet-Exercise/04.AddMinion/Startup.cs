namespace _04.AddMinion
{
    using System;
    using System.Linq;
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
            var minionInformation = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Where(e => e != "Minion:")
                                    .ToArray();
            var minionName = minionInformation[0];
            var minionAge = minionInformation[1];
            var minionTown = minionInformation[2];
            var villianInformation = Console.ReadLine().Replace("Villain: ", string.Empty);

            connection.Open();

            using (connection)
            {
                var transaction = connection.BeginTransaction();

                var querryText = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)
                                   INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)
                                   INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)
                                   INSERT INTO Towns (Name) VALUES (@townName)
                                   SELECT Id FROM Towns WHERE Name = @townName";

                try
                {
                    var command = new SqlCommand(querryText, connection);
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@villainId", villianInformation);
                    command.Parameters.AddWithValue("@nam", minionName);
                    command.Parameters.AddWithValue("@age", minionAge);
                    command.Parameters.AddWithValue("@townName", minionTown);

                    //Commit the transaction.
                    transaction.Commit();
                    Console.WriteLine("Request executed successfully");
                }
                catch (Exception ex)
                {
                    // Handle the exception if the transaction fails to commit.
                    Console.WriteLine(ex.Message);

                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
            }
        }
    }
}