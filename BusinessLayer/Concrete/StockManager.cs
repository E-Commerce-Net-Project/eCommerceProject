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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StockManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateStockDto t)
        {
            var value = _mapper.Map<CreateStockDto, Stock>(t);
            _unitOfWork.StockDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.StockDal.GetByID(id);
            _unitOfWork.StockDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultStockDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultStockDto>>(_unitOfWork.StockDal.GetList());
            return new SuccessDataResult<List<ResultStockDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultStockDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultStockDto>(_unitOfWork.StockDal.GetByID(id));
            return new SuccessDataResult<ResultStockDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateStockDto t)
        {
            var values = _mapper.Map<UpdateStockDto>(_unitOfWork.StockDal.GetByID(t.ID));
            var _contact = _mapper.Map<UpdateStockDto, Stock>(values);
            _unitOfWork.StockDal.Update(_contact);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
