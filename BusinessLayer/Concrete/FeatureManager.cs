using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
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
        IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public IResult TAdd(Feature t)
        {
            _featureDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(Feature t)
        {
            _featureDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<Feature>> TGetList()
        {
            return new SuccessDataResult<List<Feature>>(_featureDal.GetList(), ResultMessages.SuccesMessage); 
        }

        public IDataResult<Feature> TGeyByID(int id)
        {
            return new SuccessDataResult<Feature>(_featureDal.GetByID(id), ResultMessages.SuccesMessage); 
        }

        public IResult TUpdate(Feature t)
        {
            _featureDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
