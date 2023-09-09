using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class SimpleCloset1Controller : Controller
    {
        [Route("/closet-1")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
