using Microsoft.AspNetCore.Mvc;
using MiljoeFest.Shared;
using Dapper;

namespace MiljoeFest.Server.Controllers
{
    [ApiController]
    [Route("userController")]
    public class UserController : Controller
    {
        private readonly ISQLRepository _sqlRepository;

        private DBContext DBContext = new();

        public UserController(ISQLRepository i)
        {
            _sqlRepository = i;
        }

        [HttpGet("getUsers")]
        public async Task<IEnumerable<User>> GetUsers([FromQuery] int role)

        {
            var list = await _sqlRepository.GetUsers(role);


            return list;
        }

        [HttpGet("getUser")]
        public async Task<IEnumerable<User>> GetUser([FromQuery] int userId)

        {
            var user = await _sqlRepository.GetUser(userId);


            return user;
        }

        [HttpPost("create")]
        public async Task CreateUser( User u)
        {
            await _sqlRepository.CreateUser(u);
        }

        [HttpPut("update")]
        public async Task UpdateUser(int userId, User u)
        {
            await _sqlRepository.UpdateUser(userId, u);
        }

        [HttpDelete("delete")]
        public async Task DeleteUser(int userId)
        {
            await _sqlRepository.DeleteUser(userId);
        }

        [HttpGet("userShifts")]
        public async Task<IEnumerable<Shift>> UserShifts(int userId)
        {
            List<Shift> shifts = new();
            var list = await _sqlRepository.GetUserShifts(userId);
            foreach (Shift s in list)
            {
                shifts.Add(s);
            }

            return shifts;
        }
    }
}
