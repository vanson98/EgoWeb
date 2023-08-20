using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class Solution2Controller : Controller
    {

        [Route("/solution-2")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
