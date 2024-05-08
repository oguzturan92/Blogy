using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        BlogyContext context = new BlogyContext();

        public List<Article> GetArticlesByWriter(int id)
        {
            var values = context.Articles
                                .Where(i => i.AppUserId == id)
                                .ToList();
            return values;
        }

        public List<Article> GetArticleWithWriter()
        {
            var values = context.Articles
                                .Include(x => x.AppUser)
                                .ToList();
            return values;
        }

        public Article GetArticleAndWriter(int id)
        {
            var value = context.Articles
                                .Where(i => i.ArticleId == id)
                                .Include(i => i.AppUser)
                                .Include(i => i.Category)
                                .Include(i => i.Tag)
                                .Include(i => i.Comments.OrderBy(i => i.CommentDate))
                                .FirstOrDefault();
            return value;
        }
    }
}