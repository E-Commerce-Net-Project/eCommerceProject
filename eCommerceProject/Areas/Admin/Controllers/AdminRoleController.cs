﻿using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.AppRoleDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using eCommerceProject.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Roller";
            ViewBag.Title2 = "Roller";
            ViewBag.Title2Url = "/Admin/AdminRole/Index";
            ViewBag.Button = "Yeni Rol Ekle";
            ViewBag.ButtonUrl = "/Admin/AdminRole/AddRole";
            #endregion
            var appRoleList = _mapper.Map<List<ResultAppRoleDto>>(_roleManager.Roles.ToList());

            
            return View(appRoleList);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Rol Ekle";
            ViewBag.Title2 = "Roller";
            ViewBag.Title2Url = "/Admin/AdminRole/Index";
            ViewBag.Button = "Yeni Rol Ekle";
            ViewBag.ButtonUrl = "/Admin/AdminRole/AddRole";
            #endregion
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(CreateAppRoleDto createAppRoleDto)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole
                {
                    Name = createAppRoleDto.Name
                };
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return LocalRedirect("/Admin/AdminRole/Index");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(createAppRoleDto);
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Rol Güncelle";
            ViewBag.Title2 = "Roller";
            ViewBag.Title2Url = "/Admin/AdminRole/Index";
            ViewBag.Button = "Yeni Rol Ekle";
            ViewBag.ButtonUrl = "/Admin/AdminRole/AddRole";
            #endregion
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            if (ModelState.IsValid)
            {
                UpdateAppRoleDto updateAppRoleDto = new UpdateAppRoleDto
                {
                    ID = values.Id,
                    Name = values.Name
                };

                return View(updateAppRoleDto);
            }

            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateAppRoleDto updateAppRoleDto)
        {

            if (ModelState.IsValid)
            {
                var values = _roleManager.Roles.Where(x => x.Id == updateAppRoleDto.ID).FirstOrDefault();
                values.Name = updateAppRoleDto.Name;
                var result = await _roleManager.UpdateAsync(values);
                if (result.Succeeded)
                {
                    return LocalRedirect("/Admin/AdminRole/Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                return View(updateAppRoleDto);
            }

            return View(updateAppRoleDto);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return LocalRedirect("/Admin/AdminRole/Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UserRoleList()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Kullanıcı Rol Listesi";
            ViewBag.Title2 = "Roller";
            ViewBag.Title2Url = "/Admin/AdminRole/Index";
            ViewBag.Button = "Yeni Rol Ekle";
            ViewBag.ButtonUrl = "/Admin/AdminRole/AddRole";
            #endregion

            var appUserRoleList = _mapper.Map<List<ResultAppUserRoleDto>>(_userManager.Users.ToList());
            return View(appUserRoleList);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Kullanıcı Rol Listesi";
            ViewBag.Title2 = "Roller";
            ViewBag.Title2Url = "/Admin/AdminRole/Index";
            ViewBag.Button = "Kullanıcı Rol Listesi";
            ViewBag.ButtonUrl = "/Admin/AdminRole/UserRoleList";
            #endregion
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel();
                roleAssignViewModel.RoleID = item.Id;
                roleAssignViewModel.Name = item.Name;
                roleAssignViewModel.Exists = userRoles.Contains(item.Name);
                model.Add(roleAssignViewModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach(var item in model) 
            { 
                if(item.Exists) 
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return LocalRedirect("/Admin/AdminRole/UserRoleList");
        }
    }
}
