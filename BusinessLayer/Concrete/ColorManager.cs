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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void TAdd(Color t)
        {
            _colorDal.Insert(t);
        }

        public void TDelete(Color t)
        {
            _colorDal.Delete(t);
        }

        public List<Color> TGetList()
        {
           return _colorDal.GetList();
        }

        public Color TGeyByID(int id)
        {
            return _colorDal.GetByID(id);
        }

        public void TUpdate(Color t)
        {
           _colorDal.Update(t); 
        }
    }
}
