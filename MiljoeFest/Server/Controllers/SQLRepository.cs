using MiljoeFest.Shared;
using Dapper;

namespace MiljoeFest.Server.Controllers

{
    public class SQLRepository : ISQLRepository
    {
        //create a new instance of DBContext, connecting to "festivalDB"
        private DBContext DBContext = new();

        
        // Updates a user identified by userId, changes are contained in a User object called u
        public async Task UpdateUser(int userId, User u)
        {
            //@ - tagged attributes are later specified in queryArguments
            string commandText = $@"UPDATE users
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

        // Returns a list of users with the specified role
        public async Task<IEnumerable<User>> GetUsers(int role)
        {


            //@role is a placeholder, later filled in at queryArguments
            string commandText = $@"SELECT role_id as RoleId, user_id as UserId, name, department, email, phone, skills, birthday, first_aid as FirstAid
                                    FROM users WHERE role_id = @uRole
                                    ORDER BY user_id ASC";
            
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

        // Returns a list of all users, ordered by ascending userId
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            string commandText = $@"SELECT user_id as UserId, role_id as RoleId, name, department, email, phone, skills, birthday, first_aid as FirstAid
                                    FROM users
                                    ORDER BY user_id ASC";

            IEnumerable<User>? users = null;

            try
            {
                users = await DBContext.connection.QueryAsync<User>(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return users;
        }

        // Creates a User with the specified parameters
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Deletes a User with the specified userId as a parameter
        public async Task DeleteUser(int userId)
        {
            string commandText = $"DELETE FROM users WHERE user_id = @uId";
            
            var parameters = new DynamicParameters();
            parameters.Add("uId", userId);

            await DBContext.connection.ExecuteAsync(commandText, parameters);
        }

        // Returns a list of all users, ordered by the assignmentId they belong to
        public async Task<IEnumerable<Shift>> GetAllShifts()
        {
            string commandText = $@"SELECT shift_id as ShiftId, assignment_id as AssignmentId, user_id as UserId, location, start_time as Start, end_time as End, booked_by as BookedBy, is_booked as IsBooked
                                    FROM shifts
                                    ORDER BY assignment_id";

            IEnumerable<Shift>? shifts = null;


            try
            {
                shifts = await DBContext.connection.QueryAsync<Shift>(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return shifts;
        }

        // Returns a list of shifts that are either booked or not booked, using "booked" as a parameter
        public async Task<IEnumerable<Shift>> GetShifts(bool booked)
        {
            string commandText = $@"SELECT shift_id as ShiftId, assignment_id as AssignmentId, user_id as UserId, location, start_time as Start, end_time as End, booked_by as BookedBy, is_booked as IsBooked
                                    FROM shifts
                                    WHERE is_booked = @booked
                                    ORDER BY assignment_id";
            
            IEnumerable<Shift>? shifts = null;
            
            var parameters = new DynamicParameters();
            parameters.Add("booked", booked);
            
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
        
        // Returns a list of shifts that have been booked by the specified userId as a parameter
        public async Task<IEnumerable<Shift>> GetUserShifts(int userId)
        {
            string commandText = $@"SELECT shift_id as ShiftId, user_id as UserId, location, start_time as Start, end_time as End, booked_by as BookedBy, is_booked as IsBooked
                 FROM shifts
                 WHERE booked_by = @uId";
            
            IEnumerable<Shift>? shifts = null;
            
            var parameters = new DynamicParameters();
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

        // Deletes a Shift with the specified shiftId as a parameter
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

        // Creates a Shift with the specified parameters
        public async Task CreateShift(Shift s)
        {
            string commandText = $"INSERT INTO shifts (assignment_id, user_id, location, start_time, end_time, booked_by, is_booked) VALUES (@asId, @uId, @loc, @sStart, @sEnd, @sBookedBy, @sBooked)";
            
            var parameters = new DynamicParameters();
            parameters.Add("asId", s.AssignmentId);
            parameters.Add("uId", s.UserId);
            parameters.Add("loc", s.Location);
            parameters.Add("sStart", s.Start);
            parameters.Add("sEnd", s.End);
            parameters.Add("sBookedBy", s.BookedBy);
            parameters.Add("sBooked", s.IsBooked);
            
            try
            {
                await DBContext.connection.ExecuteAsync(commandText, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        // Update a shift identified by shiftId, changes are contained in a Shift object called s
        public async Task UpdateShift(int shiftId, Shift s)
        {
            //@ - tagged attributes are later specified in queryArguments
            string commandText =
                $@"UPDATE shifts
                    SET shift_id = @sId, assignment_id = @asId, user_id = @uId, location = @loc, start_time = @sStart, end_time = @sEnd, booked_by = @sBookedBy, is_booked = @booked
                    Where shift_id = @sId";

            var parameters = new DynamicParameters();
            parameters.Add("sId", s.ShiftId);
            parameters.Add("asId", s.AssignmentId);
            parameters.Add("uId", s.UserId);
            parameters.Add("loc", s.Location);
            parameters.Add("sStart", s.Start);
            parameters.Add("sEnd", s.End);
            parameters.Add("booked", s.IsBooked);
            parameters.Add("sBookedBy", s.BookedBy);

            try
            {
                await DBContext.connection.ExecuteAsync(commandText, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        // Creates an Assignment with the specified parameters
        public async Task CreateAssignment(Assignment a)
        {
            string commandText =
                $@"INSERT INTO assignments(user_id, assignment_name, department, start_time, end_time)
                    VALUES(@UserId, @aName, @aDep, @aStart, @aEnd)";

            var parameters = new DynamicParameters();
            parameters.Add("UserId", a.UserId);
            parameters.Add("aName", a.AssignmentName);
            parameters.Add("aDep", a.Department);
            parameters.Add("aStart", a.Start);
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

        // Returns a list all of Assignments
        public async Task<IEnumerable<Assignment>> GetAssignments()
        {
            string commandText =
                $@"SELECT assignment_id as assignmentId, user_id as userId, assignment_name as assignmentName, department, start_time as start, end_time as end, status
                   FROM assignments ORDER BY user_id";

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

        // Deletes an Assignment with the specified assignmentId as a parameter
        public async Task DeleteAssignment(int assignmentId)
        {
            string commandText = $@"DELETE FROM assignments WHERE assignment_id = @aId";
            
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

        // Updates an Assignment identified by assignmentId, changes are contained in an Assignment object called a
        public async Task UpdateAssignment(int assignmentId, Assignment a)
        {
            string commandText = $@"UPDATE assignments 
                                    SET user_id = @UserId, assignment_name = @aName, department = @aDep, start_time = @aStart, end_time = @aEnd, status = @aStatus
                                    WHERE assignment_id = @aAssignmentId";
            
            var parameters = new DynamicParameters();
            parameters.Add("UserId", a.UserId);
            parameters.Add("aName", a.AssignmentName);
            parameters.Add("aDep", a.Department);
            parameters.Add("aStart", a.Start);
            parameters.Add("aEnd", a.End);
            parameters.Add("aStatus", a.Status);
            parameters.Add("aAssignmentId", assignmentId);

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
