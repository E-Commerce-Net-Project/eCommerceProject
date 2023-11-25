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
        private readonly ISponsorDal _sponsorDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SponsorManager(IUnitOfWork unitOfWork, IMapper mapper, ISponsorDal sponsorDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sponsorDal = sponsorDal;
        }

        public IResult TAdd(CreateSponsorDto t)
        {
            var value = _mapper.Map<CreateSponsorDto, Sponsor>(t);
            _sponsorDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _sponsorDal.GetByID(id);
            _sponsorDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultSponsorDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultSponsorDto>>(_sponsorDal.GetList());
            return new SuccessDataResult<List<ResultSponsorDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultSponsorDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultSponsorDto>(_sponsorDal.GetByID(id));
            return new SuccessDataResult<ResultSponsorDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateSponsorDto t)
        {
            var _sponsor = _mapper.Map<UpdateSponsorDto, Sponsor>(t);
            _sponsorDal.Update(_sponsor);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
