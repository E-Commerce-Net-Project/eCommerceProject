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
    public class BodySizeManager : IBodySizeService
    {
        IBodySizeDal _bodySizeDal;

        public BodySizeManager(IBodySizeDal bodySizeDal)
        {
            _bodySizeDal = bodySizeDal;
        }

        public IResult TAdd(BodySize t)
        {
            _bodySizeDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(BodySize t)
        {
            _bodySizeDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<BodySize>> TGetList()
        {
            return new SuccessDataResult<List<BodySize>>(_bodySizeDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<BodySize> TGeyByID(int id)
        {
            return new SuccessDataResult<BodySize>(_bodySizeDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(BodySize t)
        {
            _bodySizeDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
