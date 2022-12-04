using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class EviEnglishController : Controller
    {
        [Route("/evi-english")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
