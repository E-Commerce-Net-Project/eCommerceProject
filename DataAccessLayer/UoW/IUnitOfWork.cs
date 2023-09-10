using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UoW
{
    public interface IUnitOfWork
    {
        IAboutDal AboutDal { get; }
        IMainCategoryDal MainCategoryDal { get; }
        IGenreCategoryDal GenreCategoryDal { get; }
        ISubCategoryDal SubCategoryDal { get; }
        IContactUsDal ContactUsDal { get; }
        IBrandDal BrandDal { get; }
        IContactDal ContactDal { get; }
        IBodySizeDal BodySizeDal { get; }
        IFeatureDal FeatureDal { get; }
        IServiceDal ServiceDal { get; }
        ISocialMediaDal SocialMediaDal { get; }
        ISponsorDal SponsorDal { get; }
        ITagDal TagDal { get; }
        IColorDal ColorDal { get; }
        ICommentDal CommentDal { get; }
        IProductDal ProductDal { get; }
        IProductDetailDal ProductDetailDal { get; }
        IStockDal StockDal { get; }
        void Commit();
    }
}
