using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public IAboutDal AboutDal { get; private set; }

        public IMainCategoryDal MainCategoryDal { get; private set; }

        public IGenreCategoryDal GenreCategoryDal {get; private set;}

        public ISubCategoryDal SubCategoryDal {get; private set;}

        public IContactUsDal ContactUsDal {get; private set;}

        public IBrandDal BrandDal {get; private set;}

        public IContactDal ContactDal {get; private set;}

        public IBodySizeDal BodySizeDal {get; private set;}

        public IFeatureDal FeatureDal {get; private set;}

        public IServiceDal ServiceDal {get; private set;}

        public ISocialMediaDal SocialMediaDal {get; private set;}

        public ISponsorDal SponsorDal {get; private set;}

        public ITagDal TagDal {get; private set;}

        public IColorDal ColorDal {get; private set;}

        public ICommentDal CommentDal {get; private set;}

        public IProductDal ProductDal {get; private set;}

        public IProductDetailDal ProductDetailDal {get; private set;}

        public IStockDal StockDal {get; private set;}

        public UnitOfWork(Context context)
        {
            _context = context;
            AboutDal = new EfAboutDal(_context); 
            MainCategoryDal = new EfMainCategoryDal(_context);
            GenreCategoryDal = new EfGenreCategoryDal(_context);
            SubCategoryDal = new EfSubCategoryDal(_context);
            ContactDal = new EfContactDal(_context);
            ContactUsDal = new EfContactUsDal(_context);
            BrandDal = new EfBrandDal(_context);
            BodySizeDal = new EfBodySizeDal(_context);
            FeatureDal = new EfFeatureDal(_context);
            ServiceDal = new EfServiceDal(_context);
            SocialMediaDal = new EfSocialMediaDal(_context);
            SponsorDal = new EfSponsorDal(_context);
            TagDal = new EfTagDal(_context);
            ColorDal = new EfColorDal(_context);
            CommentDal = new EfCommentDal(_context);
            ProductDal = new EfProductDal(_context);
            ProductDetailDal = new EfProductDetailDal(_context);
            StockDal = new EfStockDal(_context);
        }

        

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
