using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.GenreCategoryDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IGenreCategoryService 
    {
        IResult TAdd(CreateGenreCategoryDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateGenreCategoryDto t);
        IDataResult<List<ResultGenreCategoryDto>> TGetList();
        IDataResult<ResultGenreCategoryDto> TGeyByID(int id);
        IDataResult<List<GenreCategory>> TGenreCategoriesListWithSubCategory();
    }
}
