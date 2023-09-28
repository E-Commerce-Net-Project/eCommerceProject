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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateCommentDto t)
        {
            var value = _mapper.Map<CreateCommentDto, Comment>(t);
            _unitOfWork.CommentDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.CommentDal.GetByID(id);
            _unitOfWork.CommentDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultCommentDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultCommentDto>>(_unitOfWork.CommentDal.GetList());
            return new SuccessDataResult<List<ResultCommentDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultCommentDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultCommentDto>(_unitOfWork.CommentDal.GetByID(id));
            return new SuccessDataResult<ResultCommentDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateCommentDto t)
        {
            var values = _mapper.Map<UpdateCommentDto>(_unitOfWork.CommentDal.GetByID(t.ID));
            var _comment = _mapper.Map<UpdateCommentDto, Comment>(values);
            _unitOfWork.CommentDal.Update(_comment);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
