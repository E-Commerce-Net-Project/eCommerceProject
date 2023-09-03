using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfSubCategoryDal : GenericRepository<SubCategory>, ISubCategoryDal
    {
        private readonly Context _context;

        public EfSubCategoryDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<SubCategory> SubCategoriesListWithMainCategory()
        {
            return _context.Set<SubCategory>().Include(x => x.MainCategory).ToList();
        }
    }
}

