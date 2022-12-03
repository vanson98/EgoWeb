using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLS.Service.NewsService;
using TLS.ViewModels.News;

namespace TLS.Web.Controllers
{
    [Authorize]
    public class CmsNewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;

        public CmsNewsController(INewsService newsService, IMapper mapper)
        {
            _newsService = newsService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var message = Request.Query["message"].ToString();
            var code = Request.Query["code"].ToString();
            if (!string.IsNullOrEmpty(message) && code == "200")
            {
                ViewBag.SuccessMess = message;
            }

            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateNewsInputDto input)
        {
            var result = await _newsService.Create(input);
            return Json(result);
        }

    }
}
