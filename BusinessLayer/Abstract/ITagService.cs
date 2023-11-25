using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.TagDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ITagService 
    {
        IResult TAdd(CreateTagDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateTagDto t);
        IDataResult<List<ResultTagDto>> TGetList();
        IDataResult<ResultTagDto> TGetByID(int id);
    }
}
