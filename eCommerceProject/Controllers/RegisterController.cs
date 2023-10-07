using AutoMapper;
using BusinessLayer.ValidationRules.AppUser;
using DtoLayer.Dtos.AppUserDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;

namespace eCommerceProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterAppUserDto registerAppUserDto)
        {
            RegisterAppUserDtoValidator rv = new RegisterAppUserDtoValidator();
            ValidationResult results = rv.Validate(registerAppUserDto);
            if(results.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Name = registerAppUserDto.Name,
                    Surname = registerAppUserDto.Surname,
                    Email = registerAppUserDto.Email,
                    UserName = registerAppUserDto.UserName
                };

                if (registerAppUserDto.Password == registerAppUserDto.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, registerAppUserDto.Password);

                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByNameAsync(registerAppUserDto.UserName);
                        await _userManager.AddToRoleAsync(user, "Member");
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }

                    }
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return View(registerAppUserDto);

        }
    }
}
