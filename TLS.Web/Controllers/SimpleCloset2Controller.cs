using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class SimpleCloset2Controller : Controller
    {
        [Route("/simple-closet-2")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
