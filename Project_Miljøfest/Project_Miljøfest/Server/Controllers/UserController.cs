using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using Npgsql;
using Project_Miljøfest.Shared;

namespace Project_Miljøfest.Server.Controllers
{
    [ApiController]
    [Route("[userController]")]
    public class UserController : Controller
    {
        private ISQLRepository? _sqlRepository;


        [HttpPost("create")]
        public async Task CreateUser(User u)
        {
           await _sqlRepository.CreateUser(u);
        }

        [HttpPost("update")]
        public async Task UpdateUser(int userId, User u)
        {
             await _sqlRepository.UpdateUser(userId, u);
        }

        
    }
}
