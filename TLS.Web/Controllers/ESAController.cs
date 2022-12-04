using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class ESAController : Controller
    {
        [Route("/esa-english")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
