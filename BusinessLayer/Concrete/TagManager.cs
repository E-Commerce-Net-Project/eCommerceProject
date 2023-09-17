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
    public class TagManager : ITagService
    {
        ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public IResult TAdd(Tag t)
        {
            _tagDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(Tag t)
        {
            _tagDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<Tag>> TGetList()
        {
            return new SuccessDataResult<List<Tag>>(_tagDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<Tag> TGeyByID(int id)
        {
            return new SuccessDataResult<Tag>(_tagDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(Tag t)
        {
            _tagDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
