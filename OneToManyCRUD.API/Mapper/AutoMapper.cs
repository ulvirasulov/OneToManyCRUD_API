﻿using AutoMapper;
using OneToManyCRUD.API.DTOs.CategoryDTOs;
using OneToManyCRUD.API.DTOs.ProductDTOs;
using OneToManyCRUD.API.DTOs.TagDTOs;
using OneToManyCRUD.Business.DTOs.CategoryDTOs;
using OneToManyCRUD.Core.Entities;

namespace OneToManyCRUD.API.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();
            CreateMap<CreateTagDTO, Tags>();
        }
    }
}
