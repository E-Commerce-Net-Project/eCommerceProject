using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.ColorDtos;
using DtoLayer.Dtos.ContactUsDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IColorService 
    {
        IResult TAdd(CreateColorDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateColorDto t);
        IDataResult<List<ResultColorDto>> TGetList();
        IDataResult<ResultColorDto> TGetByID(int id);
    }
}
