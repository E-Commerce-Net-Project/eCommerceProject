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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult TAdd(Brand t)
        {
            _brandDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(Brand t)
        {
            _brandDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<Brand>> TGetList()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<Brand> TGeyByID(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.GetByID(id), ResultMessages.SuccesMessage); 
        }

        public IResult TUpdate(Brand t)
        {
            _brandDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
