using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public WriterController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult WriterList()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult WriterCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WriterCreate(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var appUser = new AppUser()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Surname = model.Surname,
                    UserName = model.Username,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    IsActive = model.IsActive
                };
                
                var result = await _userManager.CreateAsync(appUser, model.Password);

                if (!string.IsNullOrEmpty(model.RoleName))
                { 
                    await _userManager.AddToRoleAsync(appUser, model.RoleName);
                }

                if (result.Succeeded)
                {
                    return RedirectToAction("WriterList", "Writer");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                return RedirectToAction("WriterCreate", "Writer");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> WriterUpdate(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var selectRole = await _userManager.GetRolesAsync(user);
            var getRole = _roleManager.Roles.FirstOrDefault().Name;

            var model = new UserUpdateModel()
            {
                Id = id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
                Description = user.Description,
                ImageUrl = user.ImageUrl,
                IsActive = user.IsActive,
                SelectRole = selectRole.FirstOrDefault(),
                GetRole = getRole
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterUpdate(UserUpdateModel model, string roleName)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.UserName = model.UserName;
            user.Email = model.Email.ToLower();
            user.Description = model.Description;
            user.ImageUrl = model.ImageUrl;
            user.IsActive = model.IsActive;

            var sonuc = await _userManager.UpdateAsync(user);
            if (sonuc.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                
                if (userRoles.Count() > 0)
                {
                    await _userManager.RemoveFromRoleAsync(user, userRoles.FirstOrDefault());   
                }
                if (!string.IsNullOrEmpty(roleName))
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }
            return RedirectToAction("WriterList", "Writer");
        }

        public async Task<IActionResult> WriterDelete(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user);
            return RedirectToAction("WriterList", "Writer");
        }
    }
}