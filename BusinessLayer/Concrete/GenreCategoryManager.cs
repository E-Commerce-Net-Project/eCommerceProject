using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.SubCategoryDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GenreCategoryManager : IGenreCategoryService
    {
        private readonly IGenreCategoryDal _genreCategoryDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreCategoryManager(IUnitOfWork unitOfWork, IMapper mapper, IGenreCategoryDal genreCategoryDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _genreCategoryDal = genreCategoryDal;
        }

        public IResult TAdd(CreateGenreCategoryDto t)
        {
            var value = _mapper.Map<CreateGenreCategoryDto, GenreCategory>(t);
            _genreCategoryDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _genreCategoryDal.GetByID(id);
            _genreCategoryDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultGenreCategoryDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultGenreCategoryDto>>(_genreCategoryDal.GetList());
            return new SuccessDataResult<List<ResultGenreCategoryDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultGenreCategoryDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultGenreCategoryDto>(_genreCategoryDal.GetByID(id));
            return new SuccessDataResult<ResultGenreCategoryDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateGenreCategoryDto t)
        {
            var _genreCategory = _mapper.Map<UpdateGenreCategoryDto, GenreCategory>(t);
            _genreCategoryDal.Update(_genreCategory);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultGenreCategoryDto>> TGenreCategoriesListWithSubCategory()
        {
            var values = _mapper.Map<List<ResultGenreCategoryDto>>(_genreCategoryDal.GenreCategoriesListWithSubCategory());
            return new SuccessDataResult<List<ResultGenreCategoryDto>>(values, ResultMessages.SuccesMessage);
        }
    }
}
