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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly Context _context;

        public EfProductDal(Context context) : base(context)
        {
            _context = context;
        }

        public void ChangeStatus(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                product.IsActive = !product.IsActive;
                _context.SaveChanges();
            }
        }

        public List<Product> GetGenreCategoriesAndBrandsByProduct()
        {
            return _context.Set<Product>().Include(x => x.Brand).Include(x => x.GenreCategory).ToList();
        }
    }
}