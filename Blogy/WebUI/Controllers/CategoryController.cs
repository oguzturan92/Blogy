using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
		private readonly ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		public IActionResult CategoryList()
		{
			var values = _categoryService.GetAll();
			return View(values);
		}

		[HttpGet]
		public IActionResult CategoryCreate()
		{
            return View();
		}

		[HttpPost]
		public IActionResult CategoryCreate(Category category)
		{
			_categoryService.Create(category);
			return RedirectToAction("CategoryList", "Category");
		}

		[HttpGet]
		public IActionResult CategoryEdit(int id)
		{
			var value = _categoryService.GetById(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult CategoryEdit(Category category)
		{
			_categoryService.Update(category);
			return RedirectToAction("CategoryList", "Category");
		}

		public IActionResult CategoryDelete(int id)
		{
			var entity = _categoryService.GetById(id);
			_categoryService.Delete(entity);
			return RedirectToAction("CategoryList", "Category");
		}
    }
}