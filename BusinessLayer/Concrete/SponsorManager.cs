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
    public class SponsorManager : ISponsorService
    {
        ISponsorDal _sponsorDal;

        public SponsorManager(ISponsorDal sponsorDal)
        {
            _sponsorDal = sponsorDal;
        }

        public IResult TAdd(Sponsor t)
        {
            _sponsorDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(Sponsor t)
        {
            _sponsorDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<Sponsor>> TGetList()
        {
            return new SuccessDataResult<List<Sponsor>>(_sponsorDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<Sponsor> TGeyByID(int id)
        {
            return new SuccessDataResult<Sponsor>(_sponsorDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(Sponsor t)
        {
            _sponsorDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
