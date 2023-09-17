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
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public IResult TAdd(Service t)
        {
            _serviceDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(Service t)
        {
            _serviceDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<Service>> TGetList()
        {
            return new SuccessDataResult<List<Service>>(_serviceDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<Service> TGeyByID(int id)
        {
            return new SuccessDataResult<Service>(_serviceDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(Service t)
        {
            _serviceDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
