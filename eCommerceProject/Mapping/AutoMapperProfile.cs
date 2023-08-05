using AutoMapper;
using DtoLayer.Dtos.AboutDto;
using DtoLayer.Dtos.AppUserDto;
using DtoLayer.Dtos.BodySizeDto;
using DtoLayer.Dtos.BrandDto;
using DtoLayer.Dtos.ColorDto;
using DtoLayer.Dtos.CommentDto;
using DtoLayer.Dtos.ContactDto;
using DtoLayer.Dtos.ContactUsDto;
using DtoLayer.Dtos.FeatureDto;
using DtoLayer.Dtos.GenreCategoryDto;
using DtoLayer.Dtos.MainCategoryDto;
using DtoLayer.Dtos.StockDto;
using DtoLayer.Dtos.SubCategoryDto;
using DtoLayer.Dtos.TagDto;
using DtoLayer.Dtos.WishListDto;
using EntityLayer.Concrete;

namespace eCommerceProject.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

            CreateMap<AppUser, LoginAppUserDto>().ReverseMap();
            CreateMap<AppUser, RegisterAppUserDto>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserDto>().ReverseMap();

            CreateMap<BodySize, ResultBodySizeDto>().ReverseMap();
            CreateMap<BodySize, CreateBodySizeDto>().ReverseMap();
            CreateMap<BodySize, UpdateBodySizeDto>().ReverseMap();

            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();

            CreateMap<Color, ResultColorDto>().ReverseMap();
            CreateMap<Color, CreateColorDto>().ReverseMap();
            CreateMap<Color, UpdateColorDto>().ReverseMap();

            CreateMap<Comment, ResultCommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();

            CreateMap<ContactUs, ResultContactUsDto>().ReverseMap();
            CreateMap<ContactUs, CreateContactUsDto>().ReverseMap();
            CreateMap<ContactUs, UpdateContactUsDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

            CreateMap<GenreCategory, ResultGenreCategoryDto>().ReverseMap();
            CreateMap<GenreCategory, CreateGenreCategoryDto>().ReverseMap();
            CreateMap<GenreCategory, UpdateGenreCategoryDto>().ReverseMap();

            CreateMap<MainCategory, ResultMainCategoryDto>().ReverseMap();
            CreateMap<MainCategory, CreateMainCategoryDto>().ReverseMap();
            CreateMap<MainCategory, UpdateMainCategoryDto>().ReverseMap();

            CreateMap<Stock, ResultStockDto>().ReverseMap();
            CreateMap<Stock, CreateStockDto>().ReverseMap();
            CreateMap<Stock, UpdateStockDto>().ReverseMap();

            CreateMap<SubCategory, ResultSubCategoryDto>().ReverseMap();
            CreateMap<SubCategory, CreateSubCategoryDto>().ReverseMap();
            CreateMap<SubCategory, UpdateSubCategoryDto>().ReverseMap();

            CreateMap<Tag, ResultTagDto>().ReverseMap();
            CreateMap<Tag, CreateTagDto>().ReverseMap();
            CreateMap<Tag, UpdateTagDto>().ReverseMap();

            CreateMap<WishList, ResultWishListDto>().ReverseMap();
            CreateMap<WishList, CreateWishListDto>().ReverseMap();
            CreateMap<WishList, UpdateWishListDto>().ReverseMap();
        }
    }
}
