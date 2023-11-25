using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ProductDetailDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductDetailManager : IProductDetailService
    {
        private readonly IProductDetailDal _productDetailDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductDetailManager(IUnitOfWork unitOfWork, IMapper mapper, IProductDetailDal productDetailDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productDetailDal = productDetailDal;
        }

        public IResult TAdd(CreateProductDetailDto t)
        {
            var value = _mapper.Map<CreateProductDetailDto, ProductDetail>(t);
            _productDetailDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _productDetailDal.GetByID(id);
            _productDetailDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultProductDetailDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultProductDetailDto>>(_productDetailDal.GetList());
            return new SuccessDataResult<List<ResultProductDetailDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultProductDetailDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultProductDetailDto>(_productDetailDal.GetByID(id));
            return new SuccessDataResult<ResultProductDetailDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateProductDetailDto t)
        {
            var _productDetail = _mapper.Map<UpdateProductDetailDto, ProductDetail>(t);
            _productDetailDal.Update(_productDetail);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
