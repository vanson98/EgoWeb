using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class HaNoiPaint2Controller : Controller
    {
        [Route("/hanoi-paint-social")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
