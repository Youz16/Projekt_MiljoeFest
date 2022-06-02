using Microsoft.AspNetCore.Mvc;
using MiljoeFest.Shared;

namespace MiljoeFest.Server.Controllers
{
    [ApiController]
    [Route("shiftController")]
    public class ShiftController : Controller
    {
        private readonly ISQLRepository _sqlRepository;

        public ShiftController(ISQLRepository i)
        {
            _sqlRepository = i;
        }

        [HttpGet("getAllShifts")]
        public async Task<IEnumerable<Shift>> GetAllShifts()
        {

            var list = await _sqlRepository.GetAllShifts();

            return list;
        }

        [HttpGet("getShifts")]
        public async Task<IEnumerable<Shift>> GetShifts([FromQuery] bool booked)
        {
          
            var list = await _sqlRepository.GetShifts(booked);
           
            return list;
        }

        [HttpGet("getUserShifts")]
        public async Task<IEnumerable<Shift>> GetUserShifts([FromQuery] int userId)
        {
            
            var list = await _sqlRepository.GetUserShifts(userId);

            return list;
        }


        [HttpDelete("delete")]
        public async Task DeleteShift([FromQuery] int shiftId)
        {
            await _sqlRepository.DeleteShift(shiftId);
        }

        [HttpPost("create")]
        public async Task CreateShift(Shift s)
        {
            await _sqlRepository.CreateShift(s);
        }

        [HttpPut("update")]
        public async Task UpdateShift([FromQuery] int shiftId, Shift s)
        {
            await _sqlRepository.UpdateShift(shiftId, s);
        }
    }
}
