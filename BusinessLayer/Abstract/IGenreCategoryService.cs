using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IGenreCategoryService : IGenericService<GenreCategory>
    {
        IDataResult<List<GenreCategory>> TGenreCategoriesListWithSubCategory();
    }
}
