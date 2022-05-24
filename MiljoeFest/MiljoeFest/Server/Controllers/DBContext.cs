using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace MiljoeFest.Server.Controllers
{
    public class DBContext
    {
        //create variables to connection contain the connection to database.
        public NpgsqlConnection connection;

        //used to access extension configuration
        

        //create a connection to a database, using secure ConnectionString.
        public DBContext()
        {
            
            connection = new NpgsqlConnection("UserID = Postgres; Password = dbAdmin1!; Host = miljofest-db.postgres.database.azure.com; Port = 5432; Database = MiljofestDB;");
            connection.Open();
        }
    }
}//"Server=miljofest-db.postgres.database.azure.com;Database=MiljoDB;Port=5432;User Id=Postgres;Password=dbAdmin1!;Ssl Mode=Require;"  //string ConnectionString =  _configuration.GetConnectionString(input);
