﻿using Core.DataAccessLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMainCategoryDal : GenericRepository<MainCategory>, IMainCategoryDal
    {
        public EfMainCategoryDal(Context context) : base(context)
        {
        }
    }
}
