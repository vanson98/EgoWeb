using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TLS.Models;
using TLS.Common.Util;
using TLS.Common.Const;
using Microsoft.EntityFrameworkCore;
using TLS.Common.Enums.Extension;
using Microsoft.Extensions.Configuration;
using TLS.Service.NewsService;

namespace TLS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsService _newsService;
        private IConfiguration Configuration;
        public HomeController(ILogger<HomeController> logger, INewsService newsService,IConfiguration configuration)
        {
            _logger = logger;
            _newsService = newsService;
            Configuration = configuration;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
