using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class SolutionController : Controller
    {

        [Route("/solution")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
