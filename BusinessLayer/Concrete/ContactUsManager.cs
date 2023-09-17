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
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;
        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public IResult TAdd(ContactUs t)
        {
            _contactUsDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(ContactUs t)
        {
            _contactUsDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ContactUs>> TGetList()
        {
            return new SuccessDataResult<List<ContactUs>>(_contactUsDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<ContactUs> TGeyByID(int id)
        {
            return new SuccessDataResult<ContactUs>(_contactUsDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(ContactUs t)
        {
            _contactUsDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
