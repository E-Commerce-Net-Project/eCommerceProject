using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ColorDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorManager(IUnitOfWork unitOfWork, IMapper mapper, IColorDal colorDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _colorDal = colorDal;
        }

        public IResult TAdd(CreateColorDto t)
        {
            var value = _mapper.Map<CreateColorDto, Color>(t);
            _colorDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _colorDal.GetByID(id);
            _colorDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultColorDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultColorDto>>(_colorDal.GetList());
            return new SuccessDataResult<List<ResultColorDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultColorDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultColorDto>(_colorDal.GetByID(id));
            return new SuccessDataResult<ResultColorDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateColorDto t)
        {
            var color = _mapper.Map<UpdateColorDto, Color>(t);
            _colorDal.Update(color);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

    }
}
