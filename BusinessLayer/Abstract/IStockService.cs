using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.StockDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IStockService 
    {
        IResult TAdd(CreateStockDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateStockDto t);
        IDataResult<List<ResultStockDto>> TGetList();
        IDataResult<ResultStockDto> TGetByID(int id);
    }
}
