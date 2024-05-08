using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace WebUI.Areas.Writer.Models
{
    public class BlogModel
    {
		public int ArticleId { get; set; }
		public string ArticleTitle { get; set; }
		public string ArticleDescription { get; set; }
		public string ArticleCoverImageUrl { get; set; }
		public bool ArticlePopularPost { get; set; }
		public DateTime ArticleCreatedDate { get; set; }
		public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
		public int CategoryId { get; set; }
		public int TagId { get; set; }
		public int AppUserId { get; set; }
    }
}