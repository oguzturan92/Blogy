using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult CategoryList()
        {
            var categorys = _categoryService.GetAll();
            return View(categorys);
        }
        
        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category()
                {
                    CategoryName = model.CategoryName
                };
                _categoryService.Create(entity);
                return RedirectToAction("CategoryList", "Category");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var category = _categoryService.GetById(id);
            var model = new CategoryModel()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CategoryUpdate(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category()
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName
                };
                _categoryService.Update(entity);
                return RedirectToAction("CategoryList", "Category");
            }
            return View(model);
        }

        public IActionResult CategoryDelete(int id)
        {
            var entity = _categoryService.GetById(id);
            _categoryService.Delete(entity);
            return RedirectToAction("CategoryList", "Category");
        }
    
    }
}