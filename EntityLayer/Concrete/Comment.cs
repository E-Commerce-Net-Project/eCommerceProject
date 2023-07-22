using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        
        public int CommentID { get; set; }

        public int UserID { get; set; }
        public string CommentText { get; set; }
       
        public string StarCount { get; set; }
    }
}
