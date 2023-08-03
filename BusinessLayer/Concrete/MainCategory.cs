using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MainCategory : IMainCategoryService
    {
        IMainCategoryDal _mainCategoryDal;

        public MainCategory(IMainCategoryDal mainCategoryDal)
        {
            _mainCategoryDal = mainCategoryDal;
        }

        public void TAdd(EntityLayer.Concrete.MainCategory t)
        {
            _mainCategoryDal.Insert(t);
        }

        public void TDelete(EntityLayer.Concrete.MainCategory t)
        {
           _mainCategoryDal.Delete(t);
        }

        public List<EntityLayer.Concrete.MainCategory> TGetList()
        {
            return _mainCategoryDal.GetList();
        }

        public EntityLayer.Concrete.MainCategory TGeyByID(int id)
        {
            return _mainCategoryDal.GetByID(id);
        }

        public void TUpdate(EntityLayer.Concrete.MainCategory t)
        {
            _mainCategoryDal.Update(t);
        }
    }
}
