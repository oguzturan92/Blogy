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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
		BlogyContext context = new BlogyContext();

        public List<Category> GetCategoriesAndCounts()
        {
            var categories = context.Categories
                                    .Include(i => i.Articles)
									.ToList();
			return categories;
        }

        public List<Category> GetCategoriesAndCounts(int userId)
        {
            var categories = context.Categories
                                    .Include(i => i.Articles.Where(i => i.AppUserId == userId))
									.ToList();
			return categories;
        }
    }
}