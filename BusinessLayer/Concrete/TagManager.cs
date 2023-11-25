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
        private readonly ITagDal _tagDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagManager(IUnitOfWork unitOfWork, IMapper mapper, ITagDal tagDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tagDal = tagDal;
        }

        public IResult TAdd(CreateTagDto t)
        {
            var value = _mapper.Map<CreateTagDto, Tag>(t);
            _tagDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _tagDal.GetByID(id);
            _tagDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultTagDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultTagDto>>(_tagDal.GetList());
            return new SuccessDataResult<List<ResultTagDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultTagDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultTagDto>(_tagDal.GetByID(id));
            return new SuccessDataResult<ResultTagDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateTagDto t)
        {
            //var values = _mapper.Map<UpdateTagDto>(_tagDal.GetByID(t.ID));
            var _tag = _mapper.Map<UpdateTagDto, Tag>(t);
            _tagDal.Update(_tag);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
