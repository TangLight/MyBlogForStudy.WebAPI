﻿using AutoMapper;
using MyBlog.Model.DTO;
using MyBlog.Model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Utility._AutoMapper
{

    public class CustomAutoMapperProfile : Profile
    {
        public CustomAutoMapperProfile()
        {
            base.CreateMap<WriterInfo, WriterDTO>();
            base.CreateMap<BlogNews, BlogNewsDTO>()
              .ForMember(dest => dest.TypeName, sourse => sourse.MapFrom(src => src.TypeInfo.Name))
              .ForMember(dest => dest.WriterName, sourse => sourse.MapFrom(src => src.WriterInfo.Name));
            base.CreateMap<BlogDTO, Blog>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Cate));
        }
    }
}
