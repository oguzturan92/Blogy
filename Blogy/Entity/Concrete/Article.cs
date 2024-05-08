using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Article
    {
		public int ArticleId { get; set; }
		public string ArticleTitle { get; set; }
		public string ArticleDescription { get; set; }
		public string ArticleCoverImageUrl { get; set; }
		public bool ArticlePopularPost { get; set; }
		public DateTime ArticleCreatedDate { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }

		public int AppUserId { get; set; }
		public AppUser AppUser { get; set; }

		public int TagId { get; set; }
		public Tag Tag { get; set; }

		public List<Comment> Comments { get; set; }
    }
}