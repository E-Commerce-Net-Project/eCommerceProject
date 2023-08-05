using AutoMapper;
using DtoLayer.Dtos.AboutDtos;
using DtoLayer.Dtos.AppUserDtos;
using DtoLayer.Dtos.BodySizeDtos;
using DtoLayer.Dtos.BrandDtos;
using DtoLayer.Dtos.ColorDtos;
using DtoLayer.Dtos.CommentDtos;
using DtoLayer.Dtos.ContactDtos;
using DtoLayer.Dtos.ContactUsDtos;
using DtoLayer.Dtos.FeatureDtos;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using DtoLayer.Dtos.StockDtos;
using DtoLayer.Dtos.SubCategoryDtos;
using DtoLayer.Dtos.TagDtos;
using DtoLayer.Dtos.WishListDtos;
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
