using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ISubCategoryService : IGenericService<SubCategory>
    {
        IDataResult<List<SubCategory>> TSubCategoriesListWithMainCategory();
    }
}
