namespace _01.InitialSetup
{
    using System.Data.SqlClient;

    public class Startup
    {
        private static string connectionString =
            "Server=DESKTOP-ERAGAG4\\SQLEXPRESS;" +
            "Database={0};" +
            "Integrated Security=true";
        private const string DBName = "MinionsDB";

        public static void Main(string[] args)
        {
            var connection = new SqlConnection(String.Format(connectionString, "master"));
            connection.Open();

            using (connection)
            {
                try
                {
                    var queryText = "CREATE DATABASE MinionsDB";
                    var createDbCommand = new SqlCommand(queryText, connection);

                    createDbCommand.ExecuteNonQuery();

                    Console.WriteLine("Database created successfully!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was error creating database!");
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            connection = new SqlConnection(string.Format(connectionString, DBName));
            connection.Open();

            using (connection)
            {
                var querytext = @"CREATE DATABASE MinionsDB

                                  CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))

                                  CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))

                                  CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))

                                  CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))

                                  CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))

                                  CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";
                var createTableCmd = new SqlCommand(querytext, connection);

                try
                {
                    createTableCmd.ExecuteNonQuery();
                    Console.WriteLine("Table created successfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was error processing your create request!");
                    Console.WriteLine(e.Message);
                }

                querytext = @"INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')

                              INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)

                              INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)

                              INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')

                              INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)

                              INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";
                var insertCmd = new SqlCommand(querytext, connection);

                try
                {
                    insertCmd.ExecuteNonQuery();
                    Console.WriteLine("Data inserted successfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was error processing your insert request");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}