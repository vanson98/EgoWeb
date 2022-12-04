using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class MejarlCosmeticController : Controller
    {
        [Route("/mejarl")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
