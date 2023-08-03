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
    public class SponsorManager : ISponsorService
    {
        ISponsorDal _sponsorDal;

        public SponsorManager(ISponsorDal sponsorDal)
        {
            _sponsorDal = sponsorDal;
        }

        public void TAdd(Sponsor t)
        {
           _sponsorDal.Insert(t);
        }

        public void TDelete(Sponsor t)
        {
            _sponsorDal.Delete(t);
        }

        public List<Sponsor> TGetList()
        {
            return _sponsorDal.GetList();
        }

        public Sponsor TGeyByID(int id)
        {
            return _sponsorDal.GetByID(id);
        }

        public void TUpdate(Sponsor t)
        {
           _sponsorDal.Update(t);
        }
    }
}
