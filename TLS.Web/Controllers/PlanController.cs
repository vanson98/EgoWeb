using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class PlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
