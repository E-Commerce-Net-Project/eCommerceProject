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

        public AboutManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateAboutDto t)
        {
            var value = _mapper.Map<CreateAboutDto, About>(t);
            _unitOfWork.AboutDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.AboutDal.GetByID(id);
            _unitOfWork.AboutDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }


        public IDataResult<List<ResultAboutDto>> TGetList()
        {
          var messages=_mapper.Map<List<ResultAboutDto>>(_unitOfWork.AboutDal.GetList());
            return new SuccessDataResult<List<ResultAboutDto>>(messages, ResultMessages.SuccesMessage);

        }

        public IDataResult<ResultAboutDto> TGeyByID(int id)
        {
            var values=_mapper.Map<ResultAboutDto>(_unitOfWork.AboutDal.GetByID(id));
            return new SuccessDataResult<ResultAboutDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateAboutDto t)
        {
            var values=_mapper.Map<UpdateAboutDto>(_unitOfWork.AboutDal.GetByID(t.ID));
            var _about = _mapper.Map<UpdateAboutDto, About>(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);

        }
    }
}
