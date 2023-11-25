using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.CommentDtos;
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
        private readonly ICommentDal _commentDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentManager(IUnitOfWork unitOfWork, IMapper mapper, ICommentDal commentDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _commentDal = commentDal;
        }

        public IResult TAdd(CreateCommentDto t)
        {
            var value = _mapper.Map<CreateCommentDto, Comment>(t);
            _commentDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _commentDal.GetByID(id);
            _commentDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultCommentDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultCommentDto>>(_commentDal.GetList());
            return new SuccessDataResult<List<ResultCommentDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<UpdateCommentDto> TGeyByID(int id)
        {
            var values = _mapper.Map<UpdateCommentDto>(_commentDal.GetByID(id));
            return new SuccessDataResult<UpdateCommentDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateCommentDto t)
        {
            var _comment = _mapper.Map<UpdateCommentDto, Comment>(t);
            _commentDal.Update(_comment);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
