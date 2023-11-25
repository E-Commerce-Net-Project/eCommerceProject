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
        private readonly IBodySizeDal _bodySizeDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BodySizeManager(IUnitOfWork unitOfWork, IMapper mapper, IBodySizeDal bodySizeDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bodySizeDal = bodySizeDal;
        }

        public IResult TAdd(CreateBodySizeDto t)
        {
            var value=_mapper.Map<CreateBodySizeDto , BodySize>(t);
            _bodySizeDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
           var values=_bodySizeDal.GetByID(id);
            _bodySizeDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultBodySizeDto>> TGetList()
        {
           var messages =_mapper.Map<List<ResultBodySizeDto>>(_bodySizeDal.GetList());
            return new SuccessDataResult<List<ResultBodySizeDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultBodySizeDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultBodySizeDto>(_bodySizeDal.GetByID(id));
            return new SuccessDataResult<ResultBodySizeDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateBodySizeDto t)
        {
            //var values=_mapper.Map<UpdateBodySizeDto>(_bodySizeDal.GetByID(t.ID));
            var bodySize = _mapper.Map<UpdateBodySizeDto, BodySize>(t);
            _bodySizeDal.Update(bodySize);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
