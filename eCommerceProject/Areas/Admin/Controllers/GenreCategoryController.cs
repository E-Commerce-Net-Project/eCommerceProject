using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GenreCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<CreateGenreCategoryDto> _createValidator;
        private IValidator<UpdateGenreCategoryDto> _updateValidator;

        public GenreCategoryController(IMapper mapper, IValidator<CreateGenreCategoryDto> createValidator, IValidator<UpdateGenreCategoryDto> updateValidator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var genreCategoryValues = _mapper.Map<List<ResultGenreCategoryDto>>(_unitOfWork.GenreCategoryDal.GenreCategoriesListWithSubCategory());
            return View(genreCategoryValues);
        }

        [HttpGet]
        public IActionResult AddGenreCategory()
        {
            List<SelectListItem> SubCategoryName = (from x in _unitOfWork.SubCategoryDal.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.subCategoryName = SubCategoryName;

            return View();
        }

        [HttpPost]
        public IActionResult AddGenreCategory(CreateGenreCategoryDto createGenreCategoryDto)
        {
            var validator = _createValidator.Validate(createGenreCategoryDto);

            if (validator.IsValid)
            {
                List<SelectListItem> SubCategoryName = (from x in _unitOfWork.SubCategoryDal.GetList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.ID.ToString()
                                                        }).ToList();
                ViewBag.subCategoryName = SubCategoryName;

                var genreCategoryValue = _mapper.Map<CreateGenreCategoryDto, GenreCategory>(createGenreCategoryDto);
                _unitOfWork.GenreCategoryDal.Insert(genreCategoryValue);
                _unitOfWork.Commit();

                return LocalRedirect("/Admin/GenreCategory/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createGenreCategoryDto);
            }
        }

        public IActionResult DeleteGenreCategory(int id)
        {
            var categoryID = _unitOfWork.GenreCategoryDal.GetByID(id);
            _unitOfWork.GenreCategoryDal.Delete(categoryID);
            _unitOfWork.Commit();
            return LocalRedirect("/Admin/GenreCategory/Index");
        }

        [HttpGet]
        public IActionResult UpdateGenreCategory(int id)
        {
            List<SelectListItem> SubCategoryName = (from x in _unitOfWork.SubCategoryDal.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.subCategoryName = SubCategoryName;

            var genreCategoryValue = _mapper.Map<UpdateGenreCategoryDto>(_unitOfWork.GenreCategoryDal.GetByID(id));
            return View(genreCategoryValue);
        }

        [HttpPost]
        public IActionResult UpdateGenreCategory(UpdateGenreCategoryDto updateGenreCategoryDto)
        {
            var validator = _updateValidator.Validate(updateGenreCategoryDto);

            if (validator.IsValid)
            {
                var newGenreCategoryValue = _mapper.Map<UpdateGenreCategoryDto, GenreCategory>(updateGenreCategoryDto);
                _unitOfWork.GenreCategoryDal.Update(newGenreCategoryValue);
                _unitOfWork.Commit();

                return LocalRedirect("/Admin/GenreCategory/Index");
            }

            else
            {
                List<SelectListItem> SubCategoryName = (from x in _unitOfWork.SubCategoryDal.GetList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.ID.ToString()
                                                        }).ToList();
                ViewBag.subCategoryName = SubCategoryName;

                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateGenreCategoryDto);
            }
        }
    }
}
