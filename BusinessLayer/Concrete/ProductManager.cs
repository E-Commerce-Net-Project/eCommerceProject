using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.BrandDtos;
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
        private readonly IProductDal _productDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper, IProductDal productDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productDal = productDal;
        }

        public IDataResult<List<ResultProductDto>> TGetGenreCategoriesAndBrandsByProduct()
        {
            var messages = _mapper.Map<List<ResultProductDto>>(_productDal.GetGenreCategoriesAndBrandsByProduct());
            return new SuccessDataResult<List<ResultProductDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IResult TAdd(CreateProductDto t)
        {
            var value = _mapper.Map<CreateProductDto, Product>(t);
            _productDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _productDal.GetByID(id);
            _productDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultProductDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultProductDto>>(_productDal.GetList());
            return new SuccessDataResult<List<ResultProductDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultProductDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultProductDto>(_productDal.GetByID(id));
            return new SuccessDataResult<ResultProductDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateProductDto t)
        {
            var _product = _mapper.Map<UpdateProductDto, Product>(t);
            _productDal.Update(_product);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TChangeStatus(int id)
        {
            _productDal.ChangeStatus(id);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);

        }
    }
}
