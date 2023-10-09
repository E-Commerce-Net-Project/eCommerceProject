using AutoMapper;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.MainCategoryDtos;
using DtoLayer.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //private IValidator<CreateMainCategoryDto> _createValidator;
        //private IValidator<UpdateMainCategoryDto> _updateValidator;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var productValues = _mapper.Map<List<ResultProductDto>>(_unitOfWork.ProductDal.GetList());
            return View(productValues);
        }
    }
}
