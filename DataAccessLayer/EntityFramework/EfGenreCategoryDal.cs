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
    public class EfGenreCategoryDal : GenericRepository<GenreCategory>, IGenreCategoryDal
    {
        private readonly Context _context;

        public EfGenreCategoryDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<GenreCategory> GenreCategoriesListWithSubCategory()
        {
            return _context.Set<GenreCategory>().Include(x => x.SubCategory).ToList();
        }
    }
}
