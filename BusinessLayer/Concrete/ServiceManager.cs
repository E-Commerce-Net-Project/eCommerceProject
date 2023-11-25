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
        private readonly IServiceDal _serviceDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper, IServiceDal serviceDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serviceDal = serviceDal;
        }

        public IResult TAdd(CreateServiceDto t)
        {
            var value = _mapper.Map<CreateServiceDto, Service>(t);
            _serviceDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _serviceDal.GetByID(id);
            _serviceDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultServiceDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultServiceDto>>(_serviceDal.GetList());
            return new SuccessDataResult<List<ResultServiceDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultServiceDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultServiceDto>(_serviceDal.GetByID(id));
            return new SuccessDataResult<ResultServiceDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateServiceDto t)
        {
            var _service = _mapper.Map<UpdateServiceDto, Service>(t);
            _serviceDal.Update(_service);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
