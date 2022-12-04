using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class WorkController : Controller
    {
        [Route("/works")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
