using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreCategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateGenreCategoryDto t)
        {
            var value = _mapper.Map<CreateGenreCategoryDto, GenreCategory>(t);
            _unitOfWork.GenreCategoryDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.GenreCategoryDal.GetByID(id);
            _unitOfWork.GenreCategoryDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

      

        public IDataResult<List<ResultGenreCategoryDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultGenreCategoryDto>>(_unitOfWork.GenreCategoryDal.GetList());
            return new SuccessDataResult<List<ResultGenreCategoryDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultGenreCategoryDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultGenreCategoryDto>(_unitOfWork.GenreCategoryDal.GetByID(id));
            return new SuccessDataResult<ResultGenreCategoryDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateGenreCategoryDto t)
        {
            var values = _mapper.Map<UpdateGenreCategoryDto>(_unitOfWork.GenreCategoryDal.GetByID(t.ID));
            var _genreCategory = _mapper.Map<UpdateGenreCategoryDto, GenreCategory>(values);
            _unitOfWork.GenreCategoryDal.Update(_genreCategory);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<GenreCategory>> TGenreCategoriesListWithSubCategory()
        {
            throw new NotImplementedException();
        }
    }
}
