using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class MejarlCosmeticController : Controller
    {
        [Route("/mejarl-cosmetic")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
