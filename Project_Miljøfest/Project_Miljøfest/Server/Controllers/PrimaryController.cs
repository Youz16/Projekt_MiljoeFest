using Microsoft.AspNetCore.Mvc;
using Project_Miljøfest.Server;

namespace Project_Miljøfest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimaryController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
