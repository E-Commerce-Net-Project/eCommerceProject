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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public IResult TAdd(SocialMedia t)
        {
            _socialMediaDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(SocialMedia t)
        {
            _socialMediaDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<SocialMedia>> TGetList()
        {
            return new SuccessDataResult<List<SocialMedia>>(_socialMediaDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<SocialMedia> TGeyByID(int id)
        {
            return new SuccessDataResult<SocialMedia>(_socialMediaDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(SocialMedia t)
        {
            _socialMediaDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
