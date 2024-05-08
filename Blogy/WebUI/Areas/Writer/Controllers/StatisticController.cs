using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Admin")]
    public class StatisticController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        public StatisticController(ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public async Task<IActionResult> StatisticList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var categories = _categoryService.GetCategoriesAndCounts(user.Id);
            return View(categories);
        }
    }
}