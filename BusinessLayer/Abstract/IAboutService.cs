using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.AboutDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAboutService : IGenericService<About>
    {
        //IResult TAdd(CreateAboutDto t);
        //IResult TDelete(About t);
        //IResult TUpdate(UpdateAboutDto t);
        //IDataResult<List<ResultAboutDto>> TGetList();
        //IDataResult<ResultAboutDto> TGeyByID(int id);
    }
}
