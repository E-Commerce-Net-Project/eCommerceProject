﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.CommentDto
{
   public class ResultCommentDto
    {
        public int CommentID { get; set; }
        public string CommentText { get; set; }
        public string StarCount { get; set; }
    }
}
