using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.AboutDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAboutDal _aboutDal;

        public AboutManager(IUnitOfWork unitOfWork, IMapper mapper, IAboutDal aboutDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _aboutDal = aboutDal;
        }

        public IResult TAdd(CreateAboutDto t)
        {
            var value = _mapper.Map<CreateAboutDto, About>(t);
            _aboutDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _aboutDal.GetByID(id);
            _aboutDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }


        public IDataResult<List<ResultAboutDto>> TGetList()
        {
          var messages=_mapper.Map<List<ResultAboutDto>>(_aboutDal.GetList());
            return new SuccessDataResult<List<ResultAboutDto>>(messages, ResultMessages.SuccesMessage);

        }

        public IDataResult<ResultAboutDto> TGetByID(int id)
        {
            var values=_mapper.Map<ResultAboutDto>(_aboutDal.GetByID(id));
            return new SuccessDataResult<ResultAboutDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateAboutDto t)
        {
            var about = _mapper.Map<UpdateAboutDto, About>(t);
            _aboutDal.Update(about);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);

        }
    }
}
