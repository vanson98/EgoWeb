using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class Solution4Controller : Controller
    {

        [Route("/solution-4")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
