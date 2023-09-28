using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IMainCategoryService 
    {
        IResult TAdd(CreateMainCategoryDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateMainCategoryDto t);
        IDataResult<List<ResultMainCategoryDto>> TGetList();
        IDataResult<ResultMainCategoryDto> TGeyByID(int id);
    }
}
