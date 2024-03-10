using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class PlanExecutionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
