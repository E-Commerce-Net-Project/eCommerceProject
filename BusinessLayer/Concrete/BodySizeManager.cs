using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.BodySizeDtos;
using DtoLayer.Dtos.ContactUsDtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BodySizeManager : IBodySizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BodySizeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateBodySizeDto t)
        {
            var value=_mapper.Map<CreateBodySizeDto , BodySize>(t);
            _unitOfWork.BodySizeDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
           var values=_unitOfWork.BodySizeDal.GetByID(id);
            _unitOfWork.BodySizeDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultBodySizeDto>> TGetList()
        {
           var messages =_mapper.Map<List<ResultBodySizeDto>>(_unitOfWork.BodySizeDal.GetList());
            return new SuccessDataResult<List<ResultBodySizeDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultBodySizeDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultBodySizeDto>(_unitOfWork.BodySizeDal.GetByID(id));
            return new SuccessDataResult<ResultBodySizeDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateBodySizeDto t)
        {
            var values=_mapper.Map<UpdateBodySizeDto>(_unitOfWork.BodySizeDal.GetByID(t.ID));
            var _bodySize = _mapper.Map<UpdateBodySizeDto, BodySize>(values);
            _unitOfWork.BodySizeDal.Update(_bodySize);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
