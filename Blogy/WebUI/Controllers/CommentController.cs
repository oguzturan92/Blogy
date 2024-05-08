using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public IActionResult NewComment(CommentNewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Comment()
                {
                    CommentFullname = model.CommentFullname,
                    CommentContent = model.CommentContent.Trim(),
                    CommentDate = DateTime.Now,
                    ArticleId = model.ArticleId
                };
                _commentService.Create(entity);
                var values = JsonConvert.SerializeObject(entity);
                return Json(values);
            }
            return View(model);
        }
    }
}