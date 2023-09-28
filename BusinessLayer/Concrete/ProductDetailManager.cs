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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductDetailManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateProductDetailDto t)
        {
            var value = _mapper.Map<CreateProductDetailDto, ProductDetail>(t);
            _unitOfWork.ProductDetailDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.ProductDetailDal.GetByID(id);
            _unitOfWork.ProductDetailDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultProductDetailDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultProductDetailDto>>(_unitOfWork.ProductDetailDal.GetList());
            return new SuccessDataResult<List<ResultProductDetailDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultProductDetailDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultProductDetailDto>(_unitOfWork.ProductDetailDal.GetByID(id));
            return new SuccessDataResult<ResultProductDetailDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateProductDetailDto t)
        {
            var values = _mapper.Map<UpdateProductDetailDto>(_unitOfWork.ProductDetailDal.GetByID(t.ID));
            var _productDetail = _mapper.Map<UpdateProductDetailDto, ProductDetail>(values);
            _unitOfWork.ProductDetailDal.Update(_productDetail);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
