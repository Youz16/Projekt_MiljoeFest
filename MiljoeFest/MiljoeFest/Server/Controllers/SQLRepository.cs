using MiljoeFest.Shared;
using Dapper;

namespace MiljoeFest.Server.Controllers

{
    public class SQLRepository : ISQLRepository
    {
        //create a new instance of DBContext, connecting to "festivalDB"
        private DBContext DBContext = new();

        //Returns a list of users with the specified role
        /*public async Task<IEnumerable<User>> GetUsers(int role)
        {
            //@role is a placeholder, later filled in at queryArguments
            string commandText = $"(SELECT * FROM users WHERE role_id = @uRole";
            var queryArguments = new { uRole = role };
            var users = await DBContext.connection.QueryAsync<User>(commandText, queryArguments);
            return users;

        }
        */
        //update a user identified by userId, changes are contained in a user object called u
        public async Task UpdateUser(int userId, User u)
        {
            //@ - tagged attributes are later specified in queryArguments
            string commandText =
                $@"UPDATE users
                    SET role_id = @uRole, department = @uDepartment, name = @uName, phone = @uPhone, email = @uEmail, birthday = @uBirthDay, skills = @uSkills, first_aid = @uFirstAid
                    WHERE user_id = @uId";
            var parameters = new DynamicParameters();

            parameters.Add("uRole", u.RoleId);
            parameters.Add("uDepartment", u.Department);
            parameters.Add("uName", u.Name);
            parameters.Add("uPhone", u.Phone);
            parameters.Add("uEmail", u.Email);
            parameters.Add("uBirthDay", u.BirthDay);
            parameters.Add("uSkills", u.Skills);
            parameters.Add("uFirstAid", u.FirstAid);
            parameters.Add("uId", userId);



            await DBContext.connection.ExecuteAsync(commandText, parameters);


        }

        
        public async Task<IEnumerable<User>> GetUsers( int role)
        {

            
            //@role is a placeholder, later filled in at queryArguments
            string commandText = $@"SELECT user_id as UserId, name, department, email, phone, skills, birthday, first_aid as FirstAid
                                    FROM users WHERE role_id = @uRole";
            IEnumerable<User>? users = null;
            var parameters = new DynamicParameters();
            parameters.Add("uRole", role);
            try
            {
                users = await DBContext.connection.QueryAsync<User>(commandText, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return users;
        }

        public async Task<IEnumerable<User>> GetUser(int userId)
        {
            string commandText = $"SELECT * FROM users WHERE user_id = @uId";
            IEnumerable<User>? u = null;
            var parameters = new DynamicParameters();
            parameters.Add("uId", userId);
            try
            {
                
                u = await DBContext.connection.QueryAsync<User>(commandText, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return u;
        }

        public async Task CreateUser(User u)
        {
            //@ - tagged attributes are specified in queryArguments
            string commandText = $"INSERT INTO users (role_id, department, name, email, phone, birthday, skills, first_aid) VALUES (@uRole, @uDepartment, @uName, @uEmail, @uPhone,@uBirthDay, @uSkills, @uFirstAid)";

            var parameters = new DynamicParameters();

            parameters.Add("uRole", u.RoleId);
            parameters.Add("uDepartment", u.Department);
            parameters.Add("uName", u.Name);
            parameters.Add("uEmail", u.Email);
            parameters.Add("uPhone", u.Phone);
            parameters.Add("uBirthDay", u.BirthDay);
            parameters.Add("uSkills", u.Skills);
            parameters.Add("uFirstAid", u.FirstAid);
            try
            {
                await DBContext.connection.ExecuteAsync(commandText, parameters);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteUser(int userId)
        {
            string commandText = $"DELETE FROM users WHERE user_id = @uId";
            var parameters = new DynamicParameters();
            parameters.Add("uId", userId);

            await DBContext.connection.ExecuteAsync(commandText, parameters);
        }

        public async Task<IEnumerable<Shift>> GetShifts(int assignmentId, bool booked)
        {
            string commandText = $"SELECT shift_id as ShiftId, user_id as UserId, location, start_time as start, end_time as end, isBooked FROM shifts WHERE assignment_id = @asId AND isBooked = @booked";
            var parameters = new DynamicParameters();
            IEnumerable<Shift>? shifts = null; 
            parameters.Add("asId", assignmentId);
            parameters.Add("booked", booked);
            try
            {
                shifts = await DBContext.connection.QueryAsync<Shift>(commandText, parameters);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return shifts;
        }

        public async Task<IEnumerable<Shift>> GetUserShifts(int userId)
        {
            string commandText = $"SELECT shift_id as ShiftId, user_id as UserId, location, start_time as start, end_time as end, isBooked FROM shifts WHERE user_id = @uId";
            var parameters = new DynamicParameters();
            IEnumerable<Shift>? shifts = null;
            parameters.Add("uId", userId);
            try
            {
                 shifts = await DBContext.connection.QueryAsync<Shift>(commandText, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return shifts;
        }

        public async Task DeleteShift(int shiftId)
        {
            string commandText = $"DELETE FROM shifts WHERE shift_id = @sId";
            var parameters = new DynamicParameters();
            parameters.Add("sId", shiftId);
            try
            {
                await DBContext.connection.ExecuteAsync(commandText, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task CreateShift(Shift s)
        {
            string commandText = $"INSERT INTO shifts (shift_id as ShiftId, assignment_id as AssignmentId, user_id as UserId, location, start_time as start, end_time as end, isBooked) VALUES (@sID, @asId, @uId, @loc, @sStart, @sEnd, @booked)";
            var parameters = new DynamicParameters();
            parameters.Add("sId", s.ShiftId);
            parameters.Add("asId", s.AssignmentId);
            parameters.Add("uId", s.UserId);
            parameters.Add("loc", s.Location);
            parameters.Add("sStart", s.Start);
            parameters.Add("sEnd", s.End);
            parameters.Add("booked", s.IsBooked);
            try
            {
                await DBContext.connection.ExecuteAsync(commandText, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateShift(int shiftId, Shift s)
        {
            //@ - tagged attributes are later specified in queryArguments
            string commandText =
                $@"(UPDATE shifts
                    SET assignment_id = @asId, user_id = @uId, location = @loc, start_time = @sStart, end_time = @sEnd, isBooked = @booked
                    Where shift_id = @sId";
            var parameters = new DynamicParameters();

            parameters.Add("asId", s.AssignmentId);
            parameters.Add("uId", s.UserId);
            parameters.Add("lock", s.Location);
            parameters.Add("sStart", s.Start);
            parameters.Add("sEnd", s.End);
            parameters.Add("book", s.IsBooked);
            parameters.Add("sId", s.ShiftId);

            try
            {
                await DBContext.connection.ExecuteAsync(commandText, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async Task CreateAssignment(Assignment a, int coId)
        {
            string commandText =
                $@"INSERT INTO assignments(user_id as userId, assignment_name as assignmentName, department, start_time as start, end_time as end)
                    VALUES(@cId, @aName, @aDep, @aStart, @aEnd)";

            var parameters = new DynamicParameters();

                parameters.Add("coId", coId);
                parameters.Add("aName", a.AssignmentName);
                parameters.Add("aDep", a.Department);
                parameters.Add("aStrart", a.Start);
                parameters.Add("aEnd", a.End);

            try
            {
                await DBContext.connection.ExecuteAsync(commandText, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<IEnumerable<Assignment>> GetAssignments()
        {
            string commandText =
                $@"SELECT user_id as userId, assignment_name as assignmentName, department, start_time as start, end_time as end
                   FROM assingments ORDER BY user_Id";

            IEnumerable<Assignment>? assignments = null; 
            try
            {
                assignments = await DBContext.connection.QueryAsync<Assignment>(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return assignments;
        }        

        public async Task DeleteAssignment(int assignmentId)
        {
            string commandText =
                $@"DELETE FROM assignments WHERE shift_id = @aId";
            var parameters = new DynamicParameters();
            parameters.Add("aId", assignmentId);
            try
            {
                await DBContext.connection.ExecuteAsync(commandText, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async Task UpdateAssignment(int assignmentId, Assignment a)
        {
            string commandText =
                $@"UPDATE assignments 
                   SET user_id = @coId, assignment_name = @aName, department = @aDep, start_time = @aStart, end_time = @aEnd";
                   var parameters = new DynamicParameters();
            parameters.Add("coId", a.CoordinatorId);
            parameters.Add("aName", a.AssignmentName);
            parameters.Add("aDep", a.Department);
            parameters.Add("aStart", a.Start);
            parameters.Add("aEnd",a.End);

            try
            {
                await DBContext.connection.ExecuteAsync(commandText, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public object? GetService(Type serviceType)
        {
            return this.GetType();
        }
    }
}
