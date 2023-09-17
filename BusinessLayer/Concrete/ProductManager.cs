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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult TAdd(Product t)
        {
            _productDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(Product t)
        {
            _productDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<Product>> TGetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(), ResultMessages.SuccesMessage);
        }
        public IDataResult<Product> TGeyByID(int id)
        {
            return new SuccessDataResult<Product>(_productDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(Product t)
        {
            _productDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
