using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public IResult TAdd(About t)
        {
            _aboutDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(About t)
        {
            _aboutDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<About>> TGetList()
        {
          return new SuccessDataResult<List<About>>(_aboutDal.GetList(),ResultMessages.SuccesMessage);
        }

        public IDataResult<About> TGeyByID(int id)
        {
            return new SuccessDataResult<About>(_aboutDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(About t)
        {
            _aboutDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);

        }
    }
}
