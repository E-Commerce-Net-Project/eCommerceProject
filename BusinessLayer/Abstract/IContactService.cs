using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.ContactDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContactService 
    {
        IResult TAdd(CreateContactDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateContactDto t);
        IDataResult<List<ResultContactDto>> TGetList();
        IDataResult<ResultContactDto> TGetByID(int id);
    }
}
