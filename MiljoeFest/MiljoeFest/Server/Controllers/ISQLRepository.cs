using MiljoeFest.Shared;

namespace MiljoeFest.Server.Controllers

{
    public interface ISQLRepository 
    {
        Task<IEnumerable<User>> GetUsers(int role);

        Task<IEnumerable<User>> GetAllUsers();

        Task CreateUser(User u);

        Task<IEnumerable<Shift>> GetAllShifts();

        Task<IEnumerable<Shift>> GetShifts(bool booked);

        Task UpdateUser(int userId, User u);

        Task<IEnumerable<Shift>> GetUserShifts(int userId);

        Task DeleteUser(int userId);

        Task DeleteShift(int shiftId);

        Task CreateShift(Shift s);

        Task UpdateShift(int shiftId, Shift s);

        Task CreateAssignment(Assignment a);

        Task<IEnumerable<Assignment>> GetAssignments();

        Task DeleteAssignment(int assignmentId);
        Task UpdateAssignment(int assignmentId, Assignment a);


    }
}
