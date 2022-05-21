using Project_Miljøfest.Shared;

namespace Project_Miljøfest.Server.Controllers

{
    public interface ISQLRepository
    {
        Task<IEnumerable<User>> GetUsers(int role);
        Task CreateUser(User u);
        Task<IEnumerable<Shift>> GetShifts(int assignmentId, bool booked);

        Task UpdateUser(int userId, User u);
    }
}
