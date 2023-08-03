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
    public class BodySizeManager : IBodySizeService
    {
        IBodySizeDal _bodySizeDal;

        public BodySizeManager(IBodySizeDal bodySizeDal)
        {
            _bodySizeDal = bodySizeDal;
        }

        void IGenericService<BodySize>.TAdd(BodySize t)
        {
            _bodySizeDal.Insert(t);
        }

        void IGenericService<BodySize>.TDelete(BodySize t)
        {
          _bodySizeDal.Delete(t);
        }

        List<BodySize> IGenericService<BodySize>.TGetList()
        {
          return _bodySizeDal.GetList();
        }

        BodySize IGenericService<BodySize>.TGeyByID(int id)
        {
          return  _bodySizeDal.GetByID(id);
        }

        void IGenericService<BodySize>.TUpdate(BodySize t)
        {
           _bodySizeDal.Update(t);
        }
    }
}
