using Core.DataAccessLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfStockDal : GenericRepository<Stock>, IStockDal
    {
        private readonly Context _context;

        public EfStockDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<Stock> GetColorAndBodySizeByProductStock(int id)
        {
            return _context.Set<Stock>().Include(x => x.Color).Include(x => x.BodySize).Include(x => x.Product).Where(x => x.ProductID == id).ToList();
        }
    }
}
