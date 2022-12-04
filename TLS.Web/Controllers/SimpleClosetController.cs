using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class SimpleClosetController : Controller
    {
        [Route("/simple-closet")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
