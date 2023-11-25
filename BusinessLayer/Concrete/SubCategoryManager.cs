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
        private readonly ISubCategoryDal _subCategoryDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubCategoryManager(IUnitOfWork unitOfWork, IMapper mapper, ISubCategoryDal subCategoryDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _subCategoryDal = subCategoryDal;
        }

        public IResult TAdd(CreateSubCategoryDto t)
        {
            var value = _mapper.Map<CreateSubCategoryDto, SubCategory>(t);
            _subCategoryDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _subCategoryDal.GetByID(id);
            _subCategoryDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultSubCategoryDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultSubCategoryDto>>(_subCategoryDal.GetList());
            return new SuccessDataResult<List<ResultSubCategoryDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultSubCategoryDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultSubCategoryDto>(_subCategoryDal.GetByID(id));
            return new SuccessDataResult<ResultSubCategoryDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateSubCategoryDto t)
        {
            var _subCategory = _mapper.Map<UpdateSubCategoryDto, SubCategory>(t);
            _subCategoryDal.Update(_subCategory);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultSubCategoryDto>> TSubCategoriesListWithMainCategory()
        {
            var values= _mapper.Map<List<ResultSubCategoryDto>>(_subCategoryDal.SubCategoriesListWithMainCategory());
            return new SuccessDataResult<List<ResultSubCategoryDto>>(values, ResultMessages.SuccesMessage);
        }
    }
}
