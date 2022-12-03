using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TLS.Common.Const;
using TLS.DataProvider.Entities;
using TLS.ViewModels.News;

namespace TLS.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MappingEntityToViewModel();
            MappingViewModelToEntity();
        }

        private void MappingEntityToViewModel()
        {

        }

        private void MappingViewModelToEntity()
        {
            CreateMap<CreateNewsInputDto, News>()
                     .ForMember(d => d.ImageFileName, cf => cf.Ignore());
        }
    }
}


