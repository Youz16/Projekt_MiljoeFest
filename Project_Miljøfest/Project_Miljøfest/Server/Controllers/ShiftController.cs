﻿using Microsoft.AspNetCore.Mvc;
using Project_Miljøfest.Shared;

namespace Project_Miljøfest.Server.Controllers
{
    [ApiController]
    [Route("[shiftController]")]
    public class ShiftController : Controller
    {
        private ISQLRepository? _sqlRepository;
        
        [HttpGet("getShifts")]
        public async Task<IEnumerable<Shift>> GetShifts(int assignmentId, bool booked)
        {
            List<Shift> shifts = new();
            var list = await _sqlRepository.GetShifts(assignmentId, booked);
            foreach(Shift s in list)
            {
                shifts.Add(s);
            }

            return shifts;
        }
    }
}
