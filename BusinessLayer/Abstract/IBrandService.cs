using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.BrandDtos;
using DtoLayer.Dtos.ContactUsDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBrandService 
    {
        IResult TAdd(CreateBrandDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateBrandDto t);
        IDataResult<List<ResultBrandDto>> TGetList();
        IDataResult<ResultBrandDto> TGeyByID(int id);
    }
}
