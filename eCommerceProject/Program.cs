using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.Brand;
using BusinessLayer.ValidationRules.Color;
using BusinessLayer.ValidationRules.Contact;
using BusinessLayer.ValidationRules.About;
using BusinessLayer.ValidationRules.BodySize;
using BusinessLayer.ValidationRules.Feature;
using BusinessLayer.ValidationRules.MainCategory;
using BusinessLayer.ValidationRules.Service;
using BusinessLayer.ValidationRules.SocialMedia;
using BusinessLayer.ValidationRules.Sponsor;
using BusinessLayer.ValidationRules.Tag;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DtoLayer.Dtos.BrandDtos;
using DtoLayer.Dtos.ColorDtos;
using DtoLayer.Dtos.ContactDtos;
using DtoLayer.Dtos.AboutDtos;
using DtoLayer.Dtos.BodySizeDtos;
using DtoLayer.Dtos.FeatureDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using DtoLayer.Dtos.ServiceDtos;
using DtoLayer.Dtos.SocialMediaDtos;
using DtoLayer.Dtos.SponsorDtos;
using DtoLayer.Dtos.TagDtos;
using eCommerceProject.Models;
using EntityLayer.Concrete;
using FluentValidation;
using DtoLayer.Dtos.GenreCategoryDtos;
using BusinessLayer.ValidationRules.GenreCategory;
using DtoLayer.Dtos.SubCategoryDtos;
using BusinessLayer.ValidationRules.SubCategory;
using DataAccessLayer.UoW;
using BusinessLayer.ValidationRules;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomIdentityValidator>()
                .AddEntityFrameworkStores<Context>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

// Buraya AddScoped'ler gelecek

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IValidator<UpdateAboutDto>, UpdateAboutDtoValidator>();
builder.Services.AddScoped<IContactUsService, ContactUsManager>();
builder.Services.AddScoped<IContactUsDal, EfContactUsDal>();

builder.Services.AddScoped<IValidator<CreateMainCategoryDto>, CreateMainCategoryDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateMainCategoryDto>, UpdateMainCategoryDtoValidator>();

builder.Services.AddScoped<IValidator<CreateSubCategoryDto>, CreateSubCategoryDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateSubCategoryDto>, UpdateSubCategoryDtoValidator>();

builder.Services.AddScoped<IValidator<CreateGenreCategoryDto>, CreateGenreCategoryDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateGenreCategoryDto>, UpdateGenreCategoryDtoValidator>();

builder.Services.AddScoped<IValidator<CreateColorDto>, CreateColorDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateColorDto>, UpdateColorDtoValidator>();

builder.Services.AddScoped<IValidator<CreateBrandDto>, CreateBrandDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateBrandDto>, UpdateBrandDtoValidator>();

builder.Services.AddScoped<IValidator<CreateContactDto>, CreateContactDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateContactDto>, UpdateContactDtoValidator>();

builder.Services.AddScoped<IValidator<CreateBodySizeDto>, CreateBodySizeDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateBodySizeDto>, UpdateBodySizeDtoValidator>();

builder.Services.AddScoped<IValidator<CreateFeatureDto>, CreateFeatureDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateFeatureDto>, UpdateFeatureDtoValidator>();

builder.Services.AddScoped<IValidator<CreateServiceDto>, CreateServiceDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateServiceDto>, UpdateServiceDtoValidator>();

builder.Services.AddScoped<IValidator<CreateSocialMediaDto>, CreateSocialMediaDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateSocialMediaDto>, UpdateSocialMediaDtoValidator>();

builder.Services.AddScoped<IValidator<CreateSponsorDto>, CreateSponsorDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateSponsorDto>, UpdateSponsorDtoValidator>();

builder.Services.AddScoped<IValidator<CreateTagDto>, CreateTagDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateTagDto>, UpdateTagDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
