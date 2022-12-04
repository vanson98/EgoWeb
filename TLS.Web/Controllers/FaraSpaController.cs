using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class FaraSpaController : Controller
    {
        [Route("/fara-spa")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
