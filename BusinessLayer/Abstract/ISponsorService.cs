using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DtoLayer.Dtos.SponsorDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ISponsorService 
    {
        IResult TAdd(CreateSponsorDto t);
        IResult TDelete(int id);
        IResult TUpdate(UpdateSponsorDto t);
        IDataResult<List<ResultSponsorDto>> TGetList();
        IDataResult<ResultSponsorDto> TGetByID(int id);
    }
}
