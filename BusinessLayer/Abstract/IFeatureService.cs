using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.FeatureDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IFeatureService 
    {
        IResult TAdd(CreateFeatureDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateFeatureDto t);
        IDataResult<List<ResultFeatureDto>> TGetList();
        IDataResult<ResultFeatureDto> TGeyByID(int id);
    }
}
