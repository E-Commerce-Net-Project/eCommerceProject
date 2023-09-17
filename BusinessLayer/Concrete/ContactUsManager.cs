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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactUsManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult TAdd(CreateContactUsDto t)
        {
            var value = _mapper.Map<CreateContactUsDto, ContactUs>(t);
            _unitOfWork.ContactUsDal.Insert(value);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(int id)
        {
            var values = _unitOfWork.ContactUsDal.GetByID(id);
            _unitOfWork.ContactUsDal.Delete(values);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<ResultContactUsDto>> TGetList()
        {
            var messages = _mapper.Map<List<ResultContactUsDto>>(_unitOfWork.ContactUsDal.GetList());
            return new SuccessDataResult<List<ResultContactUsDto>>(messages, ResultMessages.SuccesMessage);
        }

        public IDataResult<ResultContactUsDto> TGeyByID(int id)
        {
            var values = _mapper.Map<ResultContactUsDto>(_unitOfWork.ContactUsDal.GetByID(id));
            return new SuccessDataResult<ResultContactUsDto>(values,ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(UpdateContactUsDto t)
        {
            var values = _mapper.Map<UpdateContactUsDto>(_unitOfWork.ContactUsDal.GetByID(t.ID));
            var _contact = _mapper.Map<UpdateContactUsDto, ContactUs>(values);
            _unitOfWork.ContactUsDal.Update(_contact);
            _unitOfWork.Commit();
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

    }
}
