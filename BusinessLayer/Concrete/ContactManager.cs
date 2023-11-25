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
        private readonly IContactDal _contactDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactManager(IUnitOfWork unitOfWork, IMapper mapper, IContactDal contactDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contactDal = contactDal;
        }

        public IResult TAdd(CreateContactDto t)
        {
            var value = _mapper.Map<CreateContactDto, Contact>(t);
            _contactDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _contactDal.GetByID(id);
            _contactDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultContactDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultContactDto>>(_contactDal.GetList());
            return new SuccessDataResult<List<ResultContactDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultContactDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultContactDto>(_contactDal.GetByID(id));
            return new SuccessDataResult<ResultContactDto>(values, ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateContactDto t)
        {
            var contact = _mapper.Map<UpdateContactDto, Contact>(t);
            _contactDal.Update(contact);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
