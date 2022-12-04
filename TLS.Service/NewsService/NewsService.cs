﻿using AutoMapper;
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
using TLS.ViewModels.DataTable;
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

        public async Task<DataTableResponse<NewsVm>> GetAllPaging(GetAllNewsPageRequest input)
        {
            var news = _repository.GetAll();

            var newsFilter = from n in news
                             where string.IsNullOrEmpty(input.Keyword) ||
                             n.Title.ToLower().Contains(input.Keyword.ToLower())
                             orderby n.CreatedDate descending
                             select n;

            var newsPaging = await newsFilter.Skip(input.StartIndex)
                                         .Take(input.PageSize)
                                         .Select(x => new NewsVm()
                                         {
                                             Id = x.Id,
                                             CreatedDate = x.CreatedDate.ToString("dd/MM/yyyy"),
                                             Author = x.Author,
                                             Title = x.Title,
                                             IsPublish = x.IsPublish,
                                             ThumnailImageUrl = "/" + AppConsts.NEWS_IMAGE_FOLDER_NAME + "/" + x.ImageFileName
                                         })
                                         .ToListAsync();

            for (int i = 0; i < newsPaging.Count; i++)
            {
                newsPaging[i].Index = i + 1 + input.StartIndex;
            }

            return new DataTableResponse<NewsVm>()
            {
                data = newsPaging,
                draw = input.Draw,
                recordsFiltered = await newsFilter.CountAsync(),
                recordsTotal = await news.CountAsync()
            };
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

        public async Task<ApiResponseDto> Edit(EditNewInputDto input)
        {
            var news = _repository.GetById(input.Id);
            if (news != null)
            {
                news.Title = input.Title;
                news.ShortDescription = input.ShortDescription;
                news.Author = input.Author;
                news.MetaDescription = input.MetaDescription;
                news.MetaKeyWord = input.MetaKeyWord;
                news.MetaTitle = input.MetaTitle;
                news.Content = input.Content;
                news.ImageTitle = input.ImageTitle;
                news.IsPublish = input.IsPublish;
                news.Tags = input.Tags;

                if (input.ImageFile != null)
                {
                    await _storageService.DeleteFileAsync(news.ImageFileName, AppConsts.NEWS_IMAGE_FOLDER_NAME);
                    news.ImageFileName = await _storageService.SaveFileAsync(input.ImageFile, AppConsts.NEWS_IMAGE_FOLDER_NAME);
                    news.ImageTitle = input.ImageTitle;
                }
                var result = await _repository.UpdateAsync(news);
                if (result > 0)
                {
                    return new ApiResponseDto()
                    {
                        Code = 200,
                        Message = "Cập nhật thành công"
                    };
                }
                else
                {
                    return new ApiResponseDto()
                    {
                        Code = 500,
                        Message = "Cập nhật thất bại"
                    };
                }
            }
            return new ApiResponseDto()
            {
                Code = 500,
                Message = "Sản phẩm không tồn tại"
            };
        }

    }
}