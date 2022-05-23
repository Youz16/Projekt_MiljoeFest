using Project_Miljøfest.Shared;

namespace Project_Miljøfest.Server.Controllers

{
    public interface ISQLRepository //: IServiceProvider
    {
        Task<IEnumerable<User>> GetUsers(int role);

        Task CreateUser(User u);

        Task<IEnumerable<Shift>> GetShifts(int assignmentId, bool booked);

        Task UpdateUser(int userId, User u);

        Task<IEnumerable<Shift>> GetUserShifts(int userId);

        Task DeleteUser(int userId);

        Task DeleteShift(int shiftId);

        Task CreateShift(Shift s);

        Task UpdateShift(int shiftId, Shift s);
    }
}
