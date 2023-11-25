using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.UoW;

using DtoLayer.Dtos.ContactUsDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        private readonly IContactUsDal _contactUsDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactUsManager(IUnitOfWork unitOfWork, IMapper mapper, IContactUsDal contactUsDal)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contactUsDal = contactUsDal;
        }

        public IResult TAdd(CreateContactUsDto t)
        {
            var value = _mapper.Map<CreateContactUsDto, ContactUs>(t);
            _contactUsDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _contactUsDal.GetByID(id);
            _contactUsDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultContactUsDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultContactUsDto>>(_contactUsDal.GetList());
            return new SuccessDataResult<List<ResultContactUsDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultContactUsDto> TGetByID(int id)
        {
            var values = _mapper.Map<ResultContactUsDto>(_contactUsDal.GetByID(id));
            return new SuccessDataResult<ResultContactUsDto>(values,ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateContactUsDto t)
        {
            var values = _mapper.Map<UpdateContactUsDto>(_contactUsDal.GetByID(t.ID));
            var _contact = _mapper.Map<UpdateContactUsDto, ContactUs>(values);
            _contactUsDal.Update(_contact);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

    }
}
