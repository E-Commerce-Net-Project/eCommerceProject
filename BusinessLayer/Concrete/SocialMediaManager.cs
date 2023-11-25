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
        private readonly ISocialMediaDal _socialMediaDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SocialMediaManager(IUnitOfWork unitOfWork, IMapper mapper, ISocialMediaDal socialMediaDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _socialMediaDal = socialMediaDal;
        }

        public IResult TAdd(CreateSocialMediaDto t)
        {
            var value = _mapper.Map<CreateSocialMediaDto, SocialMedia>(t);
            _socialMediaDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _socialMediaDal.GetByID(id);
            _socialMediaDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultSocialMediaDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaDal.GetList());
            return new SuccessDataResult<List<ResultSocialMediaDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultSocialMediaDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultSocialMediaDto>(_socialMediaDal.GetByID(id));
            return new SuccessDataResult<ResultSocialMediaDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateSocialMediaDto t)
        {
            var _socialMedia = _mapper.Map<UpdateSocialMediaDto, SocialMedia>(t);
            _socialMediaDal.Update(_socialMedia);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
