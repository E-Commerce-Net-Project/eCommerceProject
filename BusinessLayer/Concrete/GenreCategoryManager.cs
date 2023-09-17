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
    public class GenreCategoryManager : IGenreCategoryService
    {
        IGenreCategoryDal _genreCategoryDal;

        public GenreCategoryManager(IGenreCategoryDal genreCategoryDal)
        {
            _genreCategoryDal = genreCategoryDal;
        }

        public IDataResult<List<GenreCategory>> TGenreCategoriesListWithSubCategory()
        {
            return new SuccessDataResult<List<GenreCategory>>(_genreCategoryDal.GenreCategoriesListWithSubCategory(), ResultMessages.SuccesMessage); 
        }

        public IResult TAdd(GenreCategory t)
        {
            _genreCategoryDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(GenreCategory t)
        {
            _genreCategoryDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<GenreCategory>> TGetList()
        {
            return new SuccessDataResult<List<GenreCategory>>(_genreCategoryDal.GetList(), ResultMessages.SuccesMessage); 
        }

        public IDataResult<GenreCategory> TGeyByID(int id)
        {
            return new SuccessDataResult<GenreCategory>(_genreCategoryDal.GetByID(id), ResultMessages.SuccesMessage); 
        }

        public IResult TUpdate(GenreCategory t)
        {
            _genreCategoryDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
