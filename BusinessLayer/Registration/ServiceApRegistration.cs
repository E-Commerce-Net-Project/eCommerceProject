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
using BusinessLayer.ValidationRules.Product;
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
using DtoLayer.Dtos.ProductDtos;
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
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();

            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();

            services.AddScoped<IValidator<CreateMainCategoryDto>, CreateMainCategoryDtoValidator>();
            services.AddScoped<IValidator<UpdateMainCategoryDto>, UpdateMainCategoryDtoValidator>();
            services.AddScoped<IMainCategoryService, MainCategoryManager>();
            services.AddScoped<IMainCategoryDal, EfMainCategoryDal>();

            services.AddScoped<IValidator<CreateSubCategoryDto>, CreateSubCategoryDtoValidator>();
            services.AddScoped<IValidator<UpdateSubCategoryDto>, UpdateSubCategoryDtoValidator>();
            services.AddScoped<ISubCategoryService, SubCategoryManager>();
            services.AddScoped<ISubCategoryDal, EfSubCategoryDal>();

            services.AddScoped<IValidator<CreateGenreCategoryDto>, CreateGenreCategoryDtoValidator>();
            services.AddScoped<IValidator<UpdateGenreCategoryDto>, UpdateGenreCategoryDtoValidator>();
            services.AddScoped<IGenreCategoryService, GenreCategoryManager>();
            services.AddScoped<IGenreCategoryDal, EfGenreCategoryDal>();

            services.AddScoped<IValidator<CreateColorDto>, CreateColorDtoValidator>();
            services.AddScoped<IValidator<UpdateColorDto>, UpdateColorDtoValidator>();
            services.AddScoped<IColorService, ColorManager>();
            services.AddScoped<IColorDal, EfColorDal>();

            services.AddScoped<IValidator<CreateBrandDto>, CreateBrandDtoValidator>();
            services.AddScoped<IValidator<UpdateBrandDto>, UpdateBrandDtoValidator>();
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IBrandDal, EfBrandDal>();

            services.AddScoped<IValidator<CreateContactDto>, CreateContactDtoValidator>();
            services.AddScoped<IValidator<UpdateContactDto>, UpdateContactDtoValidator>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();

            services.AddScoped<IValidator<CreateBodySizeDto>, CreateBodySizeDtoValidator>();
            services.AddScoped<IValidator<UpdateBodySizeDto>, UpdateBodySizeDtoValidator>();
            services.AddScoped<IBodySizeService, BodySizeManager>();
            services.AddScoped<IBodySizeDal, EfBodySizeDal>();
            

            services.AddScoped<IValidator<CreateFeatureDto>, CreateFeatureDtoValidator>();
            services.AddScoped<IValidator<UpdateFeatureDto>, UpdateFeatureDtoValidator>();
            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IFeatureDal, EfFeatureDal>();

            services.AddScoped<IValidator<CreateServiceDto>, CreateServiceDtoValidator>();
            services.AddScoped<IValidator<UpdateServiceDto>, UpdateServiceDtoValidator>();
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceDal, EfServiceDal>();

            services.AddScoped<IValidator<CreateSocialMediaDto>, CreateSocialMediaDtoValidator>();
            services.AddScoped<IValidator<UpdateSocialMediaDto>, UpdateSocialMediaDtoValidator>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

            services.AddScoped<IValidator<CreateSponsorDto>, CreateSponsorDtoValidator>();
            services.AddScoped<IValidator<UpdateSponsorDto>, UpdateSponsorDtoValidator>();
            services.AddScoped<ISponsorService, SponsorManager>();
            services.AddScoped<ISponsorDal, EfSponsorDal>();

            services.AddScoped<IValidator<CreateTagDto>, CreateTagDtoValidator>();
            services.AddScoped<IValidator<UpdateTagDto>, UpdateTagDtoValidator>();
            services.AddScoped<ITagService, TagManager>();
            services.AddScoped<ITagDal, EfTagDal>();

            services.AddScoped<IValidator<CreateProductDto>, CreateProductDtoValidator>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();

            return services;
        }
    }
}
