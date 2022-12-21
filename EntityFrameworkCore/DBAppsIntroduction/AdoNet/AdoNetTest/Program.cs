namespace AdoNetTest
{
    using System;
    using System.Data.SqlClient;

    public class Program 
    {
        public static void Main()
        {
            var conection = new SqlConnection("");
            var command = new SqlCommand("SELECT", conection);

            var result = command.ExecuteReader();
        }
    } 
}
 