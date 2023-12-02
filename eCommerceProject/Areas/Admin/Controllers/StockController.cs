using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.StockDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StockController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStockService _stockService;
        private readonly IProductService _productService;
        private readonly IColorService _colorService;
        private readonly IBodySizeService _bodySizeService;

        public StockController(IStockService stockService, IMapper mapper, IProductService productService, IColorService colorService, IBodySizeService bodySizeService)
        {
            _stockService = stockService;
            _mapper = mapper;
            _productService = productService;
            _colorService = colorService;
            _bodySizeService = bodySizeService;
        }

        public IActionResult Index(int id)
        {
            var stockValues = _stockService.TGetColorAndBodySizeByProductStock(id);
            HttpContext.Session.SetInt32("Id", id);
            return View(stockValues.Data);
        }

        [HttpGet]
        public IActionResult AddStock()
        {
            List<SelectListItem> ColorName = (from x in _colorService.TGetList().Data
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.colorName = ColorName;

            List<SelectListItem> BodySizeName = (from x in _bodySizeService.TGetList().Data
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
            ViewBag.bodySizeName = BodySizeName;

            return View();
        }

        [HttpPost]
        public IActionResult AddStock(CreateStockDto createStockDto)
        {

            List<SelectListItem> ColorName = (from x in _colorService.TGetList().Data
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.colorName = ColorName;

            List<SelectListItem> BodySizeName = (from x in _bodySizeService.TGetList().Data
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
            ViewBag.bodySizeName = BodySizeName;

            int? idFromSession = HttpContext.Session.GetInt32("Id");
            createStockDto.ProductID = (int)idFromSession;
            _stockService.TAdd(createStockDto);

            return LocalRedirect($"/Admin/Stock/Index");
        }
    }
}
