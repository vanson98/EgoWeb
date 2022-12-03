
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TLS.Web.Controllers
{
    public class AboutController : Controller
    {
        private IConfiguration Configuration;

        public AboutController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [Route("/gioi-thieu")]
        public IActionResult Index()
        {
            // SEO
            ViewBag.Title = Configuration["SeoConfig:About:Title"];
            ViewBag.KeyWords = Configuration["SeoConfig:About:KeyWords"];
            ViewBag.Descriptions = Configuration["SeoConfig:About:Description"];
            ViewBag.SiteName = Configuration["SeoConfig:About:SiteName"];
            ViewBag.SiteUrl = Configuration["SeoConfig:About:SiteUrl"];
            ViewBag.SiteType = Configuration["SeoConfig:About:SiteType"];
            ViewBag.SiteImage = Configuration["SeoConfig:About:SiteImage"];
            // Data

            return View();
        }
    }
}
