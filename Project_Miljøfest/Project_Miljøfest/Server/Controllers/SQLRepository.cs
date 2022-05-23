using Project_Miljøfest.Shared;
using Dapper;
namespace Project_Miljøfest.Server.Controllers
    
{
    public class SQLRepository
    {
        //create a new instance of DBContext, connecting to "festivalDB"
        private DBContext DBContext = new("festivalDB");

        //Returns a list of users with the specified role
        public async Task<IEnumerable<User>> GetUsers(int role)
        {
            //@role is a placeholder, later filled in at queryArguments
            string commandText = $"(SELECT * FROM users WHERE role_id = @uRole";
            var queryArguments = new { uRole = role };
            var users = await DBContext.connection.QueryAsync<User>(commandText, queryArguments);
            return users;

        }
        //update a user identified by userId, changes are contained in a user object called u
        public async Task UpdateUser(int userId, User u)
        {
            //@ - tagged attributes are later specified in queryArguments
            string commandText =
                $@"(UPDATE users
                    SET name = @uName, phone = @uPhone, email = @uEmail, birth_day = @uBirthDay, skills = @uSkills, first_aid = @uFirstAid
                    WHERE user_id = @uId";

            var queryArguments = new
            {
                uName = u.Name,
                uPhone = u.Phone,
                uEmail = u.Email,
                uBirthDay = u.BirthDay,
                uSkills = u.Skills,
                uFirstAid = u.FirstAid,
                uId = userId

            };

            await DBContext.connection.ExecuteAsync(commandText, queryArguments);
            

        }

        public async Task CreateUser(User u)
        {
            //@ - tagged attributes are specified in queryArguments
            string commandText = $"INSERT INTO users (role_id, name, email, phone, skills) VALUES (@uRole, @uName, @uEmail, @uPhone, @uSkills)";

            var queryArguments = new
            {
                uRole = u.Role,
                uName = u.Name,
                uEmail = u.Email,
                uEhone = u.Phone,
                uSkills = u.Skills
            };

            await DBContext.connection.ExecuteAsync(commandText, queryArguments);
        }

        public async Task DeleteUser(int userId)
        {
            string commandText = $"DELETE FROM users WHERE user_id = @uId";
            var queryArguments = new { uId = userId };
            await DBContext.connection.ExecuteAsync(commandText, queryArguments);
        }

        public async Task<IEnumerable<Shift>> GetShifts(int assignmentId, bool booked)
        {
            string commandText = $"SELECT * FROM shifts WHERE assignment_id = @asId AND booked = @isBooked";
            var queryArguments = new { asId = assignmentId, isBooked = booked };
            var shifts = await DBContext.connection.QueryAsync<Shift>(commandText, queryArguments);
            return shifts;
        }

        public async Task<IEnumerable<Shift>> GetUserShifts(int userId)
        {
            string commandText = $"SELECT * FROM shifts WHERE user_id = @uId";
            var queryArguments = new { uId = userId };
            var shifts = await DBContext.connection.QueryAsync<Shift>(commandText, queryArguments);
            return shifts;
        }

        public async Task DeleteShift(int shiftId)
        {
            string commandText = $"DELETE FROM shifts WHERE shift_id = @sId";
            var queryArguments = new { sId = shiftId };
            await DBContext.connection.ExecuteAsync(commandText, queryArguments);
        }

        public async Task CreateShift(Shift s)
        {
            string commandText = $"INSERT INTO shifts (shift_id, assignment_id, user_id, location, start, end, is_booked) VALUES (@sID, @AsId, @uId, @loc, @sStart, @sEnd, @isBooked)";
            var queryArguments = new
            {
                sId = s.shiftId,
                asId = s.AssignmentId,
                uId = s.UserId,
                loc = s.Location,
                sStart = s.Start,
                sEnd = s.End,
                isBooked = s.IsBooked
            };

            await DBContext.connection.ExecuteAsync(commandText, queryArguments);
        }

        public async Task UpdateShift(int shiftId, Shift s)
        {
            //@ - tagged attributes are later specified in queryArguments
            string commandText =
                $@"(UPDATE shifts
                    SET assignment_id = @asId, user_id = @uId, location = @loc, start = @sStart, end = @sEnd, booked = @isBooked
                    Where shift_id = @sId";

            var queryArguments = new
            {
               asId = s.AssignmentId,
               uId = s.UserId,
               loc = s.Location,
               start = s.Start,
               end = s.End,
               isBooked = s.IsBooked,
               sId = shiftId

            };

            await DBContext.connection.ExecuteAsync(commandText, queryArguments);


        }

    }
}
