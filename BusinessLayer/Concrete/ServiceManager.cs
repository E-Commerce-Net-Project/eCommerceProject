using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ServiceDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateServiceDto t)
        {
            var value = _mapper.Map<CreateServiceDto, Service>(t);
            _unitOfWork.ServiceDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.ServiceDal.GetByID(id);
            _unitOfWork.ServiceDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultServiceDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultServiceDto>>(_unitOfWork.ServiceDal.GetList());
            return new SuccessDataResult<List<ResultServiceDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultServiceDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultServiceDto>(_unitOfWork.ServiceDal.GetByID(id));
            return new SuccessDataResult<ResultServiceDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateServiceDto t)
        {
            var values = _mapper.Map<UpdateServiceDto>(_unitOfWork.ServiceDal.GetByID(t.ID));
            var _service = _mapper.Map<UpdateServiceDto, Service>(values);
            _unitOfWork.ServiceDal.Update(_service);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
