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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult TAdd(Color t)
        {
            _colorDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(Color t)
        {
            _colorDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<Color>> TGetList()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<Color> TGeyByID(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(Color t)
        {
            _colorDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
