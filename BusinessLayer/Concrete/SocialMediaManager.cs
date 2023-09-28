using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.SocialMediaDtos;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SocialMediaManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateSocialMediaDto t)
        {
            var value = _mapper.Map<CreateSocialMediaDto, SocialMedia>(t);
            _unitOfWork.SocialMediaDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.SocialMediaDal.GetByID(id);
            _unitOfWork.SocialMediaDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultSocialMediaDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultSocialMediaDto>>(_unitOfWork.SocialMediaDal.GetList());
            return new SuccessDataResult<List<ResultSocialMediaDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultSocialMediaDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultSocialMediaDto>(_unitOfWork.SocialMediaDal.GetByID(id));
            return new SuccessDataResult<ResultSocialMediaDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateSocialMediaDto t)
        {
            var values = _mapper.Map<UpdateSocialMediaDto>(_unitOfWork.SocialMediaDal.GetByID(t.ID));
            var _socialMedia = _mapper.Map<UpdateSocialMediaDto, SocialMedia>(values);
            _unitOfWork.SocialMediaDal.Update(_socialMedia);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
