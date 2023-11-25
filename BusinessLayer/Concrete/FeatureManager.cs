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
        private readonly IFeatureDal _featureDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeatureManager(IUnitOfWork unitOfWork, IMapper mapper, IFeatureDal featureDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _featureDal = featureDal;
        }

        public IResult TAdd(CreateFeatureDto t)
        {
            var value = _mapper.Map<CreateFeatureDto, Feature>(t);
            _featureDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _featureDal.GetByID(id);
            _featureDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultFeatureDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultFeatureDto>>(_featureDal.GetList());
            return new SuccessDataResult<List<ResultFeatureDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultFeatureDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultFeatureDto>(_featureDal.GetByID(id));
            return new SuccessDataResult<ResultFeatureDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateFeatureDto t)
        {
            var feature = _mapper.Map<UpdateFeatureDto, Feature>(t);
            _featureDal.Update(feature);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
