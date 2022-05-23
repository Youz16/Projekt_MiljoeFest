using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace MiljoeFest.Server.Controllers
{
    public class DBContext
    {
        //create variables to connection contain the connection to database.
        public readonly NpgsqlConnection connection;

        //used to access extension configuration
        private readonly IConfiguration? _configuration;

        //create a connection to a database, using secure ConnectionString.
        public DBContext(string input)
        {
            string ConnectionString = _configuration.GetConnectionString(input);
            connection = new NpgsqlConnection(ConnectionString);
            connection.Open();
        }
    }
}
