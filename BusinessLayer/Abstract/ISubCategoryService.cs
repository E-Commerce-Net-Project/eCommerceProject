using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.SubCategoryDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ISubCategoryService 
    {
        IResult TAdd(CreateSubCategoryDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateSubCategoryDto t);
        IDataResult<List<ResultSubCategoryDto>> TGetList();
        IDataResult<ResultSubCategoryDto> TGetByID(int id);
        IDataResult<List<ResultSubCategoryDto>> TSubCategoriesListWithMainCategory();
    }
}
