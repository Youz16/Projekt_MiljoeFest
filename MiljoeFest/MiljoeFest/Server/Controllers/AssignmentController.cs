using Microsoft.AspNetCore.Mvc;

namespace MiljoeFest.Server.Controllers
{
    [ApiController]
    [Route("assignmentController")]
    public class AssignmentController : Controller
    {
        private readonly ISQLRepository _sqlRepository;

        public AssignmentController(ISQLRepository i)
        {
            _sqlRepository = i;
        }

        [HttpPost("createAssignment")]
       public async Task CreateAssignment(Assignment a, int coId)
        {
            await _sqlRepository.CreateAssignment(a, coId);
        }

        [HttpGet("getAssignments")]
        public async Task<IEnumerable<Assignment>> GetAssignments()
        {
           var assignments = await _sqlRepository.GetAssignments();

            return assignments;
        }

        [HttpDelete("DeleteAssignment")]
        public async Task DeleteAssignment(int assignmentId)
        {
            await _sqlRepository.DeleteAssignment(assignmentId);
        }

        [HttpPut("updateAssignment")]
        public async Task UpdateAssignment(int assignmentId, Assignment a)
        {
            await _sqlRepository.UpdateAssignment(assignmentId, a);
        }
    }
}
