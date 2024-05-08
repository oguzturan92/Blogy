using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Areas.Writer.Models;

namespace WebUI.Areas.Blog.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly ITagService _tagService;
        public BlogController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService, ICommentService commentService, ITagService tagService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
            _commentService = commentService;
            _tagService = tagService;
        }
        
        [HttpGet]
        public async Task<IActionResult> BlogList()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var articles = _articleService.GetArticlesByWriter(user.Id);
            return View(articles);
        }

        [HttpGet]
        public IActionResult BlogCreate()
        {
            var categories = (from x in _categoryService.GetAll()
                            select new SelectListItem
                            {
                                Text = x.CategoryName,
                                Value = x.CategoryId.ToString()
                            }).ToList();
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BlogCreate(Article article)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var entity = new Article()
            {
                ArticleTitle = article.ArticleTitle,
                ArticleDescription = article.ArticleDescription,
                ArticleCoverImageUrl = article.ArticleCoverImageUrl,
                CategoryId = article.CategoryId,
                AppUserId = user.Id,
                ArticleCreatedDate = DateTime.Now.Date
            };

            _articleService.Create(entity);

            return RedirectToAction("BlogList","Blog");
        }

        [HttpGet]
        public IActionResult BlogUpdate(int id)
        {
            var entity = _articleService.GetById(id);
            var model = new BlogModel()
            {
                ArticleId = entity.ArticleId,
                ArticleTitle = entity.ArticleTitle,
                ArticleDescription = entity.ArticleDescription,
                ArticleCoverImageUrl = entity.ArticleCoverImageUrl,
                ArticlePopularPost = entity.ArticlePopularPost,
                CategoryId = entity.CategoryId,
                TagId = entity.TagId,
                Categories = _categoryService.GetAll(),
                Tags = _tagService.GetAll(),
                AppUserId = entity.AppUserId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult BlogUpdate(BlogModel model)
        {
            var entity = new Article() {
                ArticleId = model.ArticleId,
                ArticleTitle = model.ArticleTitle,
                ArticleDescription = model.ArticleDescription,
                ArticleCoverImageUrl = model.ArticleCoverImageUrl,
                ArticlePopularPost = model.ArticlePopularPost,
                CategoryId = model.CategoryId,
                TagId = model.TagId,
                AppUserId = model.AppUserId
            };
            _articleService.Update(entity);
            return RedirectToAction("BlogList","Blog");
        }

        public IActionResult BlogDelete(int id)
        {
            var entity = _articleService.GetById(id);
            _articleService.Delete(entity);
            return RedirectToAction("BlogList","Blog");
        }

        public IActionResult CommentList(int id)
        {
            var comments = _commentService.GetAll().Where(i => i.ArticleId == id).OrderBy(i => i.CommentDate).ToList();
            return View(comments);
        }

        public IActionResult commentDelete(int id)
        {
            var entity = _commentService.GetById(id);
            _commentService.Delete(entity);
            return RedirectToAction("CommentList","Blog", new { id = entity.ArticleId });
        }

    }
}