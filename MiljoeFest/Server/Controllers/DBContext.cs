using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace MiljoeFest.Server.Controllers
{
    public class DBContext
    {
        // Create variable to connection contain the connection to database.
        public NpgsqlConnection connection;

        // Used to access extension configuration
        

        // Create a connection to a database, using ConnectionString.
        public DBContext()
        {
            // Specifies connection using connectionstring
            connection = new NpgsqlConnection("UserID=Systembruger;Password=dbUser1!;Host=miljofest-db.postgres.database.azure.com;Port=5432;Database=MiljofestDB;");
            // Establishes connection to the DB
            connection.Open();
        }
    }
}
