using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class Solution5Controller : Controller
    {

        [Route("/solution-5")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
