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

        [HttpGet("getShifts")]
        public async Task<IEnumerable<Shift>> GetShifts(int assignmentId, bool booked)
        {
            List<Shift> shifts = new();
            var list = await _sqlRepository.GetShifts(assignmentId, booked);
            foreach (Shift s in list)
            {
                shifts.Add(s);
            }

            return shifts;
        }

        [HttpDelete("delete")]
        public async Task DeleteShift(int shiftId)
        {
            await _sqlRepository.DeleteUser(shiftId);
        }

        [HttpPost("create")]
        public async Task CreateShift(Shift s)
        {
            await _sqlRepository.CreateShift(s);
        }

        [HttpPut("update")]
        public async Task UpdateShift(int shiftId, Shift s)
        {
            await _sqlRepository.UpdateShift(shiftId, s);
        }
    }
}
