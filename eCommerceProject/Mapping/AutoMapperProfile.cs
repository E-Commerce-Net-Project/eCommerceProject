using AutoMapper;
using DtoLayer.Dtos.AboutDtos;
using DtoLayer.Dtos.AppRoleDtos;
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
using DtoLayer.Dtos.ProductDetailDtos;
using DtoLayer.Dtos.ProductDtos;
using DtoLayer.Dtos.ServiceDtos;
using DtoLayer.Dtos.SocialMediaDtos;
using DtoLayer.Dtos.SponsorDtos;
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
            CreateMap<ResultAboutDto, UpdateAboutDto>().ReverseMap();

            CreateMap<AppUser, LoginAppUserDto>().ReverseMap();
            CreateMap<AppUser, RegisterAppUserDto>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserDto>().ReverseMap();

            CreateMap<BodySize, ResultBodySizeDto>().ReverseMap();
            CreateMap<BodySize, CreateBodySizeDto>().ReverseMap();
            CreateMap<BodySize, UpdateBodySizeDto>().ReverseMap();
            CreateMap<ResultBodySizeDto, UpdateBodySizeDto>().ReverseMap();

            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<ResultBrandDto, UpdateBrandDto>().ReverseMap();


            CreateMap<Color, ResultColorDto>().ReverseMap();
            CreateMap<Color, CreateColorDto>().ReverseMap();
            CreateMap<Color, UpdateColorDto>().ReverseMap();
            CreateMap<ResultColorDto, UpdateColorDto>().ReverseMap();


            CreateMap<Comment, ResultCommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<ResultCommentDto, UpdateCommentDto>().ReverseMap();


            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<ResultContactDto, UpdateContactDto>().ReverseMap();


            CreateMap<ContactUs, ResultContactUsDto>().ReverseMap();
            CreateMap<ContactUs, CreateContactUsDto>().ReverseMap();
            CreateMap<ContactUs, UpdateContactUsDto>().ReverseMap();
            CreateMap<ResultContactUsDto, UpdateContactUsDto>().ReverseMap();


            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<ResultFeatureDto, UpdateFeatureDto>().ReverseMap();


            CreateMap<GenreCategory, ResultGenreCategoryDto>().ReverseMap();
            CreateMap<GenreCategory, CreateGenreCategoryDto>().ReverseMap();
            CreateMap<GenreCategory, UpdateGenreCategoryDto>().ReverseMap();
            CreateMap<ResultGenreCategoryDto, UpdateGenreCategoryDto>().ReverseMap();


            CreateMap<MainCategory, ResultMainCategoryDto>().ReverseMap();
            CreateMap<MainCategory, CreateMainCategoryDto>().ReverseMap();
            CreateMap<MainCategory, UpdateMainCategoryDto>().ReverseMap();
            CreateMap<ResultMainCategoryDto, UpdateMainCategoryDto>().ReverseMap();


            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ResultProductDetailDto, UpdateProductDetailDto>().ReverseMap();


            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<ResultProductDto, UpdateProductDto>().ReverseMap();


            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();
            CreateMap<ResultServiceDto, UpdateServiceDto>().ReverseMap();


            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<ResultSocialMediaDto, UpdateSocialMediaDto>().ReverseMap();


            CreateMap<Sponsor, ResultSponsorDto>().ReverseMap();
            CreateMap<Sponsor, CreateSponsorDto>().ReverseMap();
            CreateMap<Sponsor, UpdateSponsorDto>().ReverseMap();
            CreateMap<ResultSponsorDto, UpdateSponsorDto>().ReverseMap();


            CreateMap<Stock, ResultStockDto>().ReverseMap();
            CreateMap<Stock, CreateStockDto>().ReverseMap();
            CreateMap<Stock, UpdateStockDto>().ReverseMap();
            CreateMap<ResultStockDto, UpdateStockDto>().ReverseMap();


            CreateMap<SubCategory, ResultSubCategoryDto>().ReverseMap();
            CreateMap<SubCategory, CreateSubCategoryDto>().ReverseMap();
            CreateMap<SubCategory, UpdateSubCategoryDto>().ReverseMap();
            CreateMap<ResultSubCategoryDto, UpdateSubCategoryDto>().ReverseMap();


            CreateMap<Tag, ResultTagDto>().ReverseMap();
            CreateMap<Tag, CreateTagDto>().ReverseMap();
            CreateMap<Tag, UpdateTagDto>().ReverseMap();
            CreateMap<ResultTagDto, UpdateTagDto>().ReverseMap();


            CreateMap<WishList, ResultWishListDto>().ReverseMap();
            CreateMap<WishList, CreateWishListDto>().ReverseMap();
            CreateMap<WishList, UpdateWishListDto>().ReverseMap();
            CreateMap<ResultWishListDto, UpdateWishListDto>().ReverseMap();


            CreateMap<AppRole, ResultAppRoleDto>().ReverseMap();
            CreateMap<AppRole, CreateAppRoleDto>().ReverseMap();
            CreateMap<AppRole, UpdateAppRoleDto>().ReverseMap();
            CreateMap<AppUser, ResultAppUserRoleDto>().ReverseMap();
        }
    }
}
