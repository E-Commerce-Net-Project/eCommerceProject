using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.TagDtos;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateTagDto t)
        {
            var value = _mapper.Map<CreateTagDto, Tag>(t);
            _unitOfWork.TagDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.TagDal.GetByID(id);
            _unitOfWork.TagDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultTagDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultTagDto>>(_unitOfWork.TagDal.GetList());
            return new SuccessDataResult<List<ResultTagDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultTagDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultTagDto>(_unitOfWork.TagDal.GetByID(id));
            return new SuccessDataResult<ResultTagDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateTagDto t)
        {
            var values = _mapper.Map<UpdateTagDto>(_unitOfWork.TagDal.GetByID(t.ID));
            var _tag = _mapper.Map<UpdateTagDto, Tag>(values);
            _unitOfWork.TagDal.Update(_tag);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
