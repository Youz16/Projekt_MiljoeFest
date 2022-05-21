using Project_Miljøfest.Shared;
using Dapper;
namespace Project_Miljøfest.Server.Controllers
    
{
    public class SQLRepository
    {
        private DBContext DBContext = new("festivalDB");

        public async Task<IEnumerable<User>> GetUsers(int role)
        {
            string commandText = $"(SELECT * FROM users WHERE role_id = {role}";
            var users = await DBContext.connection.QueryAsync<User>(commandText);
            return users;

        }

        public async Task UpdateUser(int userId, User u)
        {
            string commandText = $@"(UPDATE users
                                     SET name = @name, phone = @phone, email = @email, birth_day = @birthDay, skills = @skills, first_aid = @firstAid
                                     WHERE user_id = {userId}";

            var queryArguments = new
            {
                name = u.Name,
                phone = u.Phone,
                email = u.Email,
                birthDay = u.BirthDay,
                skills = u.Skills,
                firstAid = u.FirstAid

            };

            await DBContext.connection.ExecuteAsync(commandText, queryArguments);
            

        }

        public async Task CreateUser(User u)
        {
            string commandText = $"INSERT INTO users (role_id, name, email, phone, skills) VALUES (@Role, @Name, @Email, @Phone, @Skills)";

            var queryArguments = new
            {
                role_id = u.Role,
                name = u.Name,
                email = u.Email,
                phone = u.Phone,
                skills = u.Skills
            };

            await DBContext.connection.ExecuteAsync(commandText, queryArguments);
        }

        public async Task<IEnumerable<Shift>> GetShifts(int assignmentId, bool booked)
        {
            string commandText = $"SELECT * FROM shifts WHERE assignment ILIKE {assignmentId} AND booked = {booked}";
            var shifts = await DBContext.connection.QueryAsync<Shift>(commandText);
            return shifts;
        }
    }
}
