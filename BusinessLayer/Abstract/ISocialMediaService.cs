using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.SocialMediaDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ISocialMediaService 

    {
        IResult TAdd(CreateSocialMediaDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateSocialMediaDto t);
        IDataResult<List<ResultSocialMediaDto>> TGetList();
        IDataResult<ResultSocialMediaDto> TGetByID(int id);
    }
}
