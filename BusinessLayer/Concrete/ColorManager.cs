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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateColorDto t)
        {
            var value = _mapper.Map<CreateColorDto, Color>(t);
            _unitOfWork.ColorDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.ColorDal.GetByID(id);
            _unitOfWork.ColorDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultColorDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultColorDto>>(_unitOfWork.ColorDal.GetList());
            return new SuccessDataResult<List<ResultColorDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultColorDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultColorDto>(_unitOfWork.ColorDal.GetByID(id));
            return new SuccessDataResult<ResultColorDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateColorDto t)
        {
            var values = _mapper.Map<UpdateColorDto>(_unitOfWork.ColorDal.GetByID(t.ID));
            var _color = _mapper.Map<UpdateColorDto, Color>(values);
            _unitOfWork.ColorDal.Update(_color);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

    }
}
