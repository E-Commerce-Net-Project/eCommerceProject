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
    public class MainCategoryManager : IMainCategoryService
    {
        IMainCategoryDal _mainCategoryDal;

        public MainCategoryManager(IMainCategoryDal mainCategoryDal)
        {
            _mainCategoryDal = mainCategoryDal;
        }

        public IResult TAdd(MainCategory t)
        {
            _mainCategoryDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(MainCategory t)
        {
            _mainCategoryDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<MainCategory>> TGetList()
        {
            return new SuccessDataResult<List<MainCategory>>(_mainCategoryDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<MainCategory> TGeyByID(int id)
        {
            return new SuccessDataResult<MainCategory>(_mainCategoryDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(MainCategory t)
        {
            _mainCategoryDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
