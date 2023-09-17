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
    public class SubCategoryManager : ISubCategoryService
    {
        ISubCategoryDal _subCategoryDal;

        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        public IDataResult<List<SubCategory>> TSubCategoriesListWithMainCategory()
        {
            return new SuccessDataResult<List<SubCategory>>(_subCategoryDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IResult TAdd(SubCategory t)
        {
            _subCategoryDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(SubCategory t)
        {
            _subCategoryDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<SubCategory>> TGetList()
        {
            return new SuccessDataResult<List<SubCategory>>(_subCategoryDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<SubCategory> TGeyByID(int id)
        {
            return new SuccessDataResult<SubCategory>(_subCategoryDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(SubCategory t)
        {
            _subCategoryDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
