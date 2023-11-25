using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.AboutDtos;
using DtoLayer.Dtos.ContactDtos;
using DtoLayer.Dtos.ContactUsDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContactUsService 
    {
        IResult TAdd(CreateContactUsDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateContactUsDto t);
        IDataResult<List<ResultContactUsDto>> TGetList();
        IDataResult<ResultContactUsDto> TGetByID(int id);
    }
}
