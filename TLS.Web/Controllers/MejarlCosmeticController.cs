using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class MejarlCosmeticController : Controller
    {
        [Route("/majarl-cosmetic")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
