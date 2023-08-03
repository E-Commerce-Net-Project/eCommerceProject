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
    public class TagManager : ITagService
    {
        ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public void TAdd(Tag t)
        {
            _tagDal.Insert(t);
        }

        public void TDelete(Tag t)
        {
            _tagDal.Delete(t);
        }

        public List<Tag> TGetList()
        {
           return _tagDal.GetList();
        }

        public Tag TGeyByID(int id)
        {
            return _tagDal.GetByID(id);
        }

        public void TUpdate(Tag t)
        {
            _tagDal.Update(t);
        }
    }
}
