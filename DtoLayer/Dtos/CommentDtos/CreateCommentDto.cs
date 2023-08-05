using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.CommentDtos
{
    public class CreateCommentDto
    {
        public string CommentText { get; set; }
        public string StarCount { get; set; }
    }
}
