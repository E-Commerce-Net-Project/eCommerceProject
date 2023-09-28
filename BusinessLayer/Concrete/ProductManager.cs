using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ProductDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateProductDto t)
        {
            var value = _mapper.Map<CreateProductDto, Product>(t);
            _unitOfWork.ProductDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.ProductDal.GetByID(id);
            _unitOfWork.ProductDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultProductDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultProductDto>>(_unitOfWork.ProductDal.GetList());
            return new SuccessDataResult<List<ResultProductDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultProductDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultProductDto>(_unitOfWork.ProductDal.GetByID(id));
            return new SuccessDataResult<ResultProductDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateProductDto t)
        {
            var values = _mapper.Map<UpdateProductDto>(_unitOfWork.ProductDal.GetByID(t.ID));
            var _product = _mapper.Map<UpdateProductDto, Product>(values);
            _unitOfWork.ProductDal.Update(_product);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
