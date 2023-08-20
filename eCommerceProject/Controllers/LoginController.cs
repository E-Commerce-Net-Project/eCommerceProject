using BusinessLayer.ValidationRules.AppUser;
using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginAppUserDto loginAppUserDto)
        {
            LoginAppUserDtoValidator lv = new LoginAppUserDtoValidator();
            ValidationResult results = lv.Validate(loginAppUserDto);
            if (results.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginAppUserDto.UserName, loginAppUserDto.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); //Giriş Yapınca Yönleneceği Sayfa Değişecek
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
