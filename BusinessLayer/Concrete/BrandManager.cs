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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateBrandDto t)
        {
            var value = _mapper.Map<CreateBrandDto, Brand>(t);
            _unitOfWork.BrandDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.BrandDal.GetByID(id);
            _unitOfWork.BrandDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultBrandDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultBrandDto>>(_unitOfWork.BrandDal.GetList());
            return new SuccessDataResult<List<ResultBrandDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultBrandDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultBrandDto>(_unitOfWork.BrandDal.GetByID(id));
            return new SuccessDataResult<ResultBrandDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateBrandDto t)
        {
            var values = _mapper.Map<UpdateBrandDto>(_unitOfWork.ContactUsDal.GetByID(t.ID));
            var _brand = _mapper.Map<UpdateBrandDto, Brand>(values);
            _unitOfWork.BrandDal.Update(_brand);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
