using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace WebUI.Models
{
    public class BlogModel
    {
        
    }

    public class BlogListClientModel
    {
        public List<Article> Articles { get; set; }
    }

    public class BlogDetailClientModel
    {
        public Article Article { get; set; }
        public List<Article> ArticlesBottom { get; set; }
        public List<Article> PopularPosts { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories { get; set; }
    }
}