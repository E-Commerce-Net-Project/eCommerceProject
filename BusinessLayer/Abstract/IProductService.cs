using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.ProductDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IProductService 
    {
        IResult TAdd(CreateProductDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateProductDto t);
        IDataResult<List<ResultProductDto>> TGetList();
        IDataResult<ResultProductDto> TGeyByID(int id);
    }
}
