using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.SubCategoryDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubCategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateSubCategoryDto t)
        {
            var value = _mapper.Map<CreateSubCategoryDto, SubCategory>(t);
            _unitOfWork.SubCategoryDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.SubCategoryDal.GetByID(id);
            _unitOfWork.SubCategoryDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultSubCategoryDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultSubCategoryDto>>(_unitOfWork.SubCategoryDal.GetList());
            return new SuccessDataResult<List<ResultSubCategoryDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultSubCategoryDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultSubCategoryDto>(_unitOfWork.SubCategoryDal.GetByID(id));
            return new SuccessDataResult<ResultSubCategoryDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateSubCategoryDto t)
        {
            var values = _mapper.Map<UpdateSubCategoryDto>(_unitOfWork.SubCategoryDal.GetByID(t.ID));
            var _subCategory = _mapper.Map<UpdateSubCategoryDto, SubCategory>(values);
            _unitOfWork.SubCategoryDal.Update(_subCategory);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<SubCategory>> TSubCategoriesListWithMainCategory()
        {
            throw new NotImplementedException();
        }
    }
}
