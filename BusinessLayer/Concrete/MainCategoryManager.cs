﻿using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MainCategoryManager : IMainCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MainCategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateMainCategoryDto t)
        {
            var value = _mapper.Map<CreateMainCategoryDto, MainCategory>(t);
            _unitOfWork.MainCategoryDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.MainCategoryDal.GetByID(id);
            _unitOfWork.MainCategoryDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultMainCategoryDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultMainCategoryDto>>(_unitOfWork.MainCategoryDal.GetList());
            return new SuccessDataResult<List<ResultMainCategoryDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultMainCategoryDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultMainCategoryDto>(_unitOfWork.MainCategoryDal.GetByID(id));
            return new SuccessDataResult<ResultMainCategoryDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateMainCategoryDto t)
        {
            var values = _mapper.Map<UpdateMainCategoryDto>(_unitOfWork.MainCategoryDal.GetByID(t.ID));
            var _mainCategory= _mapper.Map<UpdateMainCategoryDto, MainCategory>(values);
            _unitOfWork.MainCategoryDal.Update(_mainCategory);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
