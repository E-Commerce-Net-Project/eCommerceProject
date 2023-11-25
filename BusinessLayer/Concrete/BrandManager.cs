using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.BrandDtos;
using DtoLayer.Dtos.ContactUsDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandManager(IUnitOfWork unitOfWork, IMapper mapper, IBrandDal brandDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _brandDal = brandDal;
        }

        public IResult TAdd(CreateBrandDto t)
        {
            var value = _mapper.Map<CreateBrandDto, Brand>(t);
            _brandDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _brandDal.GetByID(id);
            _brandDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultBrandDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultBrandDto>>(_brandDal.GetList());
            return new SuccessDataResult<List<ResultBrandDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultBrandDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultBrandDto>(_brandDal.GetByID(id));
            return new SuccessDataResult<ResultBrandDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateBrandDto t)
        {
            var brand = _mapper.Map<UpdateBrandDto, Brand>(t);
            _brandDal.Update(brand);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
