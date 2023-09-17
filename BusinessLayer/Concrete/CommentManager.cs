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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult TAdd(Comment t)
        {
            _commentDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(Comment t)
        {
            _commentDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<Comment>> TGetList()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<Comment> TGeyByID(int id)
        {
            return new SuccessDataResult<Comment>(_commentDal.GetByID(id), ResultMessages.SuccesMessage); 
        }

        public IResult TUpdate(Comment t)
        {
            _commentDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
