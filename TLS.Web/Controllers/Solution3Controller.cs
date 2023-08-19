using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class Solution3Controller : Controller
    {

        [Route("/solution-3")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
