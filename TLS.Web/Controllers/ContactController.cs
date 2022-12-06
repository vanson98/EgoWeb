using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class ContactController : Controller
    {
        [Route("/contact")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
