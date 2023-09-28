using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ContactDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateContactDto t)
        {
            var value = _mapper.Map<CreateContactDto, Contact>(t);
            _unitOfWork.ContactDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.ContactDal.GetByID(id);
            _unitOfWork.ContactDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultContactDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultContactDto>>(_unitOfWork.ContactDal.GetList());
            return new SuccessDataResult<List<ResultContactDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultContactDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultContactDto>(_unitOfWork.ContactDal.GetByID(id));
            return new SuccessDataResult<ResultContactDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateContactDto t)
        {
            var values = _mapper.Map<UpdateContactDto>(_unitOfWork.ContactDal.GetByID(t.ID));
            var _contact = _mapper.Map<UpdateContactDto, Contact>(values);
            _unitOfWork.ContactDal.Update(_contact);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
