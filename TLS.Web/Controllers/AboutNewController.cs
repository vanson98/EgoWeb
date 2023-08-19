using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class AboutNewController : Controller
    {
        [Route("/about-new")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
