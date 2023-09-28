using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.ServiceDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IServiceService 
    {
        IResult TAdd(CreateServiceDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateServiceDto t);
        IDataResult<List<ResultServiceDto>> TGetList();
        IDataResult<ResultServiceDto> TGeyByID(int id);
    }
}
