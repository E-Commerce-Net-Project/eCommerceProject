using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.About;
using BusinessLayer.ValidationRules.BodySize;
using BusinessLayer.ValidationRules.Brand;
using BusinessLayer.ValidationRules.Color;
using BusinessLayer.ValidationRules.Contact;
using BusinessLayer.ValidationRules.Feature;
using BusinessLayer.ValidationRules.GenreCategory;
using BusinessLayer.ValidationRules.MainCategory;
using BusinessLayer.ValidationRules.Service;
using BusinessLayer.ValidationRules.SocialMedia;
using BusinessLayer.ValidationRules.Sponsor;
using BusinessLayer.ValidationRules.SubCategory;
using BusinessLayer.ValidationRules.Tag;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.AboutDtos;
using DtoLayer.Dtos.BodySizeDtos;
using DtoLayer.Dtos.BrandDtos;
using DtoLayer.Dtos.ColorDtos;
using DtoLayer.Dtos.ContactDtos;
using DtoLayer.Dtos.FeatureDtos;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using DtoLayer.Dtos.ServiceDtos;
using DtoLayer.Dtos.SocialMediaDtos;
using DtoLayer.Dtos.SponsorDtos;
using DtoLayer.Dtos.SubCategoryDtos;
using DtoLayer.Dtos.TagDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Registration
{
    public static class ServiceApRegistration
    {
        public static IServiceCollection ServiceAp(this IServiceCollection services, IConfiguration configuration)
        {

         
         

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IValidator<UpdateAboutDto>, UpdateAboutDtoValidator>();
            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();

            services.AddScoped<IValidator<CreateMainCategoryDto>, CreateMainCategoryDtoValidator>();
            services.AddScoped<IValidator<UpdateMainCategoryDto>, UpdateMainCategoryDtoValidator>();

            services.AddScoped<IValidator<CreateSubCategoryDto>, CreateSubCategoryDtoValidator>();
            services.AddScoped<IValidator<UpdateSubCategoryDto>, UpdateSubCategoryDtoValidator>();

            services.AddScoped<IValidator<CreateGenreCategoryDto>, CreateGenreCategoryDtoValidator>();
            services.AddScoped<IValidator<UpdateGenreCategoryDto>, UpdateGenreCategoryDtoValidator>();

            services.AddScoped<IValidator<CreateColorDto>, CreateColorDtoValidator>();
            services.AddScoped<IValidator<UpdateColorDto>, UpdateColorDtoValidator>();

            services.AddScoped<IValidator<CreateBrandDto>, CreateBrandDtoValidator>();
            services.AddScoped<IValidator<UpdateBrandDto>, UpdateBrandDtoValidator>();

            services.AddScoped<IValidator<CreateContactDto>, CreateContactDtoValidator>();
            services.AddScoped<IValidator<UpdateContactDto>, UpdateContactDtoValidator>();

            services.AddScoped<IValidator<CreateBodySizeDto>, CreateBodySizeDtoValidator>();
            services.AddScoped<IValidator<UpdateBodySizeDto>, UpdateBodySizeDtoValidator>();

            services.AddScoped<IValidator<CreateFeatureDto>, CreateFeatureDtoValidator>();
            services.AddScoped<IValidator<UpdateFeatureDto>, UpdateFeatureDtoValidator>();

            services.AddScoped<IValidator<CreateServiceDto>, CreateServiceDtoValidator>();
            services.AddScoped<IValidator<UpdateServiceDto>, UpdateServiceDtoValidator>();

            services.AddScoped<IValidator<CreateSocialMediaDto>, CreateSocialMediaDtoValidator>();
            services.AddScoped<IValidator<UpdateSocialMediaDto>, UpdateSocialMediaDtoValidator>();

            services.AddScoped<IValidator<CreateSponsorDto>, CreateSponsorDtoValidator>();
            services.AddScoped<IValidator<UpdateSponsorDto>, UpdateSponsorDtoValidator>();

            services.AddScoped<IValidator<CreateTagDto>, CreateTagDtoValidator>();
            services.AddScoped<IValidator<UpdateTagDto>, UpdateTagDtoValidator>();


            return services;
        }
    }
}
