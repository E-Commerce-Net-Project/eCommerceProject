using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.BodySizeDtos;
using DtoLayer.Dtos.ContactUsDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBodySizeService 
    {
        IResult TAdd(CreateBodySizeDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateBodySizeDto t);
        IDataResult<List<ResultBodySizeDto>> TGetList();
        IDataResult<ResultBodySizeDto> TGetByID(int id);
    }
}
