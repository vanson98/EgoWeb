using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class HaNoiPaintController : Controller
    {
        [Route("/hanoi-paint-event")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
