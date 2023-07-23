﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class GenreCategory
    {
        public int GenreCategoryID { get; set; }
        public string Name { get; set; }
        public int MainCategoryID { get; set; }
        public MainCategory MainCategory { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}