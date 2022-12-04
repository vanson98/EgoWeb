using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class BlogController : Controller
    {
        [Route("/blogs")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
