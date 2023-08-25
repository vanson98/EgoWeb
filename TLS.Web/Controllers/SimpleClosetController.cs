using Microsoft.AspNetCore.Mvc;

namespace TLS.Web.Controllers
{
    public class SimpleClosetController : Controller
    {
        [Route("/du-an/tang-chuyen-doi-doanh-thu-nho-trien-khai-marketing-da-kenh-nganh-thoi-trang")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
