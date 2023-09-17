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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IResult TAdd(Contact t)
        {
            _contactDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(Contact t)
        {
            _contactDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<Contact>> TGetList()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<Contact> TGeyByID(int id)
        {
            return new SuccessDataResult<Contact>(_contactDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(Contact t)
        {
            _contactDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
