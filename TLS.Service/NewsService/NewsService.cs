using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using TLS.Common.Const;
using TLS.Common.Enums.Extension;
using TLS.Common.Util;
using TLS.DataProvider.Entities;
using TLS.Repository.Base;
using TLS.Service.Base;
using TLS.Service.Common.Storage;
using TLS.Service.NewsService;
using TLS.ViewModels.Common;
using TLS.ViewModels.News;

namespace TLS.Service.Catalog
{
    public class NewsService : BaseService<News>, INewsService
    {
        private readonly IRepository<News> _repository;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;

        public NewsService(IRepository<News> baseReponsitory, IMapper mapper, IStorageService storageService,IConfiguration configuration) : base(baseReponsitory)
        {
            _repository = baseReponsitory;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<ApiResponseDto> Create(CreateNewsInputDto input)
        {
            var news = _mapper.Map<News>(input);

            var imageFileName = await _storageService.SaveFileAsync(input.ImageFile, AppConsts.NEWS_IMAGE_FOLDER_NAME);

            news.ImageFileName = imageFileName;
            news.ImageTitle = input.ImageTitle;
            news.CreatedDate = DateTime.Now;
            var newNews = await _repository.AddAsync(news);

            if (newNews.Id > 0)
            {
                return new ApiResponseDto()
                {
                    Code = 200,
                    Message = "Tạo mới thành công"
                };
            }
            else
            {
                return new ApiResponseDto()
                {
                    Code = 500,
                    Message = "Tạo mới thất bại"
                };
            }
        }

    }
}