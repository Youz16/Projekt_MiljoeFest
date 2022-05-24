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
    }
}
