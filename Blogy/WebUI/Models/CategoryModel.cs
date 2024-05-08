using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace WebUI.Models
{
    public class CategoryModel
    {
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }

		public List<Article> Articles { get; set; }
        public List<Category> Categories { get; set; }
    }
}