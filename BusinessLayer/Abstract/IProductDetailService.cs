using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.ProductDetailDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IProductDetailService 
    {
        IResult TAdd(CreateProductDetailDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateProductDetailDto t);
        IDataResult<List<ResultProductDetailDto>> TGetList();
        IDataResult<ResultProductDetailDto> TGeyByID(int id);
    }
}
