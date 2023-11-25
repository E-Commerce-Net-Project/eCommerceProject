using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.CommentDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService 
    {
        IResult TAdd(CreateCommentDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateCommentDto t);
        IDataResult<List<ResultCommentDto>> TGetList();
        IDataResult<UpdateCommentDto> TGeyByID(int id);
    }
}
