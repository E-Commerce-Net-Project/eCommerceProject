using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GenreCategoryManager : IGenreCategoryService
    {
        IGenreCategoryDal _genreCategoryDal;

        public GenreCategoryManager(IGenreCategoryDal genreCategoryDal)
        {
            _genreCategoryDal = genreCategoryDal;
        }

        public List<GenreCategory> TGenreCategoriesListWithSubCategory()
        {
            return _genreCategoryDal.GenreCategoriesListWithSubCategory();
        }

        public void TAdd(GenreCategory t)
        {
            _genreCategoryDal.Insert(t);
        }

        public void TDelete(GenreCategory t)
        {
            _genreCategoryDal.Delete(t);
        }

        public List<GenreCategory> TGetList()
        {
            return _genreCategoryDal.GetList();
        }

        public GenreCategory TGeyByID(int id)
        {
            return _genreCategoryDal.GetByID(id);
        }

        public void TUpdate(GenreCategory t)
        {
            _genreCategoryDal.Update(t);
        }
    }
}
