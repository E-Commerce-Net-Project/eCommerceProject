using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.About;
using BusinessLayer.ValidationRules.AppRole;
using BusinessLayer.ValidationRules.AppUser;
using BusinessLayer.ValidationRules.BodySize;
using BusinessLayer.ValidationRules.Feature;
using BusinessLayer.ValidationRules.MainCategory;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DtoLayer.Dtos.AboutDtos;
using DtoLayer.Dtos.AppRoleDtos;
using DtoLayer.Dtos.AppUserDtos;
using DtoLayer.Dtos.BodySizeDtos;
using DtoLayer.Dtos.FeatureDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using eCommerceProject.Models;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

builder.Services.AddScoped<IAboutDal,EfAboutDal>();
builder.Services.AddScoped<IAboutService,AboutManager>();
builder.Services.AddScoped<IValidator<UpdateAboutDto>, UpdateAboutDtoValidator>();

builder.Services.AddScoped<IMainCategoryDal, EfMainCategoryDal>();
builder.Services.AddScoped<IMainCategoryService, MainCategoryManager>();
builder.Services.AddScoped<IValidator<CreateMainCategoryDto>, CreateMainCategoryDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateMainCategoryDto>, UpdateMainCategoryDtoValidator>();

builder.Services.AddScoped<IBodySizeDal,EfBodySizeDal>();
builder.Services.AddScoped<IBodySizeService,BodySizeManager>();
builder.Services.AddScoped<IValidator<CreateBodySizeDto>, CreateBodySizeDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateBodySizeDto>, UpdateBodySizeDtoValidator>();

builder.Services.AddScoped<IFeatureDal,EfFeatureDal>();
builder.Services.AddScoped<IFeatureService,FeatureManager>();
builder.Services.AddScoped<IValidator<CreateFeatureDto>, CreateFeatureDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateFeatureDto>,UpdateFeatureDtoValidator>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
