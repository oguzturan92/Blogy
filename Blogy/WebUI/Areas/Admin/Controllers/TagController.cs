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
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public IActionResult TagList()
        {
            var tags = _tagService.GetAll();
            return View(tags);
        }
        
        [HttpGet]
        public IActionResult TagCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TagCreate(TagModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Tag()
                {
                    TagTitle = model.TagTitle
                };
                _tagService.Create(entity);
                return RedirectToAction("TagList", "Tag");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult TagUpdate(int id)
        {
            var tag = _tagService.GetById(id);
            var model = new TagModel()
            {
                TagId = tag.TagId,
                TagTitle = tag.TagTitle
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult TagUpdate(TagModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Tag()
                {
                    TagId = model.TagId,
                    TagTitle = model.TagTitle
                };
                _tagService.Update(entity);
                return RedirectToAction("TagList", "Tag");
            }
            return View(model);
        }

        public IActionResult TagDelete(int id)
        {
            var entity = _tagService.GetById(id);
            _tagService.Delete(entity);
            return RedirectToAction("TagList", "Tag");
        }
    
    }
}