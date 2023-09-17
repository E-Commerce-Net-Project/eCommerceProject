using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
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

        public IResult TAdd(ProductDetail t)
        {
            _productDetailDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);

        }

        public IResult TDelete(ProductDetail t)
        {
            _productDetailDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ProductDetail>> TGetList()
        {
            return new SuccessDataResult<List<ProductDetail>>(_productDetailDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<ProductDetail> TGeyByID(int id)
        {
            return new SuccessDataResult<ProductDetail>(_productDetailDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(ProductDetail t)
        {
            _productDetailDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
