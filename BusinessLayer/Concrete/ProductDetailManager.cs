using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductDetailManager : IProductDetailService
    {
        IProductDetailDal _productDetailDal;

        public ProductDetailManager(IProductDetailDal productDetailDal)
        {
            _productDetailDal = productDetailDal;
        }

        public void TAdd(ProductDetail t)
        {
            _productDetailDal.Insert(t);

        }

        public void TDelete(ProductDetail t)
        {
            _productDetailDal.Delete(t);
        }

        public List<ProductDetail> TGetList()
        {
           return _productDetailDal.GetList();
        }

        public ProductDetail TGeyByID(int id)
        {
            return _productDetailDal.GetByID(id);
        }

        public void TUpdate(ProductDetail t)
        {
           _productDetailDal.Update(t);
        }
    }
}
