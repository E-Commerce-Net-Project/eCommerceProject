using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.FeatureDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeatureManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateFeatureDto t)
        {
            var value = _mapper.Map<CreateFeatureDto, Feature>(t);
            _unitOfWork.FeatureDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.FeatureDal.GetByID(id);
            _unitOfWork.FeatureDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultFeatureDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultFeatureDto>>(_unitOfWork.FeatureDal.GetList());
            return new SuccessDataResult<List<ResultFeatureDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultFeatureDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultFeatureDto>(_unitOfWork.FeatureDal.GetByID(id));
            return new SuccessDataResult<ResultFeatureDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateFeatureDto t)
        {
            var values = _mapper.Map<UpdateFeatureDto>(_unitOfWork.FeatureDal.GetByID(t.ID));
            var _feature = _mapper.Map<UpdateFeatureDto, Feature>(values);
            _unitOfWork.FeatureDal.Update(_feature);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
