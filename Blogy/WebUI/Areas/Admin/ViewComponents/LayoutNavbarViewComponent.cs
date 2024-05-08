using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class LayoutNavbarViewComponent : ViewComponent
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleManager;
        public LayoutNavbarViewComponent(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IArticleService articleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _articleManager = articleManager;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userName = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            var model = new NavbarModel()
            {
                AppUser = user,
                TotalBlogCount = _articleManager.GetAll().Where(i => i.AppUserId == user.Id).Count()
            };
            return View(model);
        } 
    }
}