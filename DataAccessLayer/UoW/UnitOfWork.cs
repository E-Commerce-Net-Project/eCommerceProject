using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public IContactUsDal ContactUsDal { get; private set; }

        public UnitOfWork(Context context)
        {
            _context = context;
        
            ContactUsDal = new EfContactUsDal(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
