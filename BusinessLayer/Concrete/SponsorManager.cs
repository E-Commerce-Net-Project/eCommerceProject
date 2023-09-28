using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.SponsorDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SponsorManager : ISponsorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SponsorManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateSponsorDto t)
        {
            var value = _mapper.Map<CreateSponsorDto, Sponsor>(t);
            _unitOfWork.SponsorDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.SponsorDal.GetByID(id);
            _unitOfWork.SponsorDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultSponsorDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultSponsorDto>>(_unitOfWork.SponsorDal.GetList());
            return new SuccessDataResult<List<ResultSponsorDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultSponsorDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultSponsorDto>(_unitOfWork.SponsorDal.GetByID(id));
            return new SuccessDataResult<ResultSponsorDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateSponsorDto t)
        {
            var values = _mapper.Map<UpdateSponsorDto>(_unitOfWork.SponsorDal.GetByID(t.ID));
            var _sponsor = _mapper.Map<UpdateSponsorDto, Sponsor>(values);
            _unitOfWork.SponsorDal.Update(_sponsor);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
