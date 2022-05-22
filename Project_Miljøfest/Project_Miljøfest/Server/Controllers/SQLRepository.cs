using Project_Miljøfest.Shared;
using Dapper;
namespace Project_Miljøfest.Server.Controllers
    
{
    public class SQLRepository
    {
        private DBContext DBContext = new("festivalDB");

        public async Task<IEnumerable<User>> GetUsers(int role)
        {
            string commandText = $"(SELECT * FROM users WHERE role_id = @role";
            var queryArguments = new { role_id = role };
            var users = await DBContext.connection.QueryAsync<User>(commandText, queryArguments);
            return users;

        }

        public async Task UpdateUser(int userId, User u)
        {
            string commandText = $@"(UPDATE users
                                     SET name = @name, phone = @phone, email = @email, birth_day = @birthDay, skills = @skills, first_aid = @firstAid
                                     WHERE user_id = @userId";

            var queryArguments = new
            {
                name = u.Name,
                phone = u.Phone,
                email = u.Email,
                birthDay = u.BirthDay,
                skills = u.Skills,
                firstAid = u.FirstAid,
                user_id = userId

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

        public async Task DeleteUser(int userId)
        {
            string commandText = $"DELETE FROM users WHERE user_id = @userId";
            var queryArguments = new { user_id = userId };
            await DBContext.connection.ExecuteAsync(commandText, queryArguments);
        }

        public async Task<IEnumerable<Shift>> GetShifts(int assignmentId, bool booked)
        {
            string commandText = $"SELECT * FROM shifts WHERE assignment_id = @assignmentId AND booked = @booked";
            var queryArguments = new { assignment_id = assignmentId, booked = booked };
            var shifts = await DBContext.connection.QueryAsync<Shift>(commandText, queryArguments);
            return shifts;
        }

        public async Task<IEnumerable<Shift>> GetUserShifts(int userId)
        {
            string commandText = $"SELECT * FROM shifts WHERE user_id = @userId";
            var queryArguments = new { user_id = userId };
            var shifts = await DBContext.connection.QueryAsync<Shift>(commandText, queryArguments);
            return shifts;
        }

        public async Task DeleteShift(int shiftId)
        {
            string commandText = $"DELETE FROM shifts WHERE shifts_id = @shiftId";
            var queryArguments = new { shift_id = shiftId };
            await DBContext.connection.ExecuteAsync(commandText, queryArguments);
        }

        public async Task CreateShift(Shift s)
        {
            string commandText = $"INSERT INTO shifts (shift_id, assignment_id, user_id, location, start, end, is_booked) VALUES (@ShiftID, @AssignmentId, @UserId, @Location, @Start, @End, @IsBooked)";
            var queryArguments = new
            {
                shift_id = s.shiftId,
                assignment_id = s.AssignmentId,
                user_id = s.UserId,
                location = s.Location,
                start = s.Start,
                ened = s.End,
                is_booked = s.IsBooked
            };

            await DBContext.connection.ExecuteAsync(commandText, queryArguments);
        }
    }
}
