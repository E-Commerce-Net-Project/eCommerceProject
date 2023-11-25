using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.StockDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StockManager : IStockService
    {
        private readonly IStockDal _stockDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StockManager(IUnitOfWork unitOfWork, IMapper mapper, IStockDal stockDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _stockDal = stockDal;
        }

        public IResult TAdd(CreateStockDto t)
        {
            var value = _mapper.Map<CreateStockDto, Stock>(t);
            _stockDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _stockDal.GetByID(id);
            _stockDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultStockDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultStockDto>>(_stockDal.GetList());
            return new SuccessDataResult<List<ResultStockDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultStockDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultStockDto>(_stockDal.GetByID(id));
            return new SuccessDataResult<ResultStockDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateStockDto t)
        {
            var _contact = _mapper.Map<UpdateStockDto, Stock>(t);
            _stockDal.Update(_contact);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
