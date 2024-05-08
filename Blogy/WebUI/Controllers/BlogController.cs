using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ITagService _tagService;
        private readonly ICategoryService _categoryService;
        public BlogController(IArticleService articleService, ITagService tagService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _tagService = tagService;
            _categoryService = categoryService;
        }

        public IActionResult BlogListClient(int? catId, int? tagId, string search)
        {
            var articles = _articleService.GetArticleWithWriter();
            if (catId != null)
            {
                articles = _articleService.GetArticleWithWriter().Where(i => i.CategoryId == catId).ToList();
            }
            if (tagId != null)
            {
                articles = _articleService.GetArticleWithWriter().Where(i => i.TagId == tagId).ToList();
            }
            if (search != null)
            {
                articles = _articleService.GetArticleWithWriter().Where(i => i.ArticleTitle.ToLower().Contains(search.ToLower())).ToList();
            }
            var model = new BlogListClientModel()
            {
                Articles = articles
            };
            return View(model);
        }

        public IActionResult BlogDetailClient(int id)
        {
            var random = new Random();
            var model = new BlogDetailClientModel()
            {
                Article = _articleService.GetArticleAndWriter(id),
                PopularPosts = _articleService.GetAll().Where(i => i.ArticlePopularPost).ToList(),
                Categories = _categoryService.GetCategoriesAndCounts(),
                Tags = _tagService.GetAll(),
                ArticlesBottom = _articleService.GetAll().OrderBy(i => random.Next()).Take(4).ToList()
            };
            return View(model);
        }

    }
}