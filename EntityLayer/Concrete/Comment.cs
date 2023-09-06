using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Common;

namespace EntityLayer.Concrete
{
    public class Comment :BaseEntity
    {
        public string CommentText { get; set; }
        public string StarCount { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
