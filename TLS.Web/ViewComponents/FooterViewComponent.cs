using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TLS.Web.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IConfiguration _configuration { get; set; }
        public FooterViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Email = _configuration["Email"];
            ViewBag.Phone = _configuration["Phone"];
            ViewBag.Zalo = _configuration["Zalo"];
            ViewBag.Address = _configuration["Address"];
            return View();
        }
    }
}
