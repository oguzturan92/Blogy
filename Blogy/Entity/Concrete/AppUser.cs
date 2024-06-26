using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Entity.Concrete
{
	public class AppUser : IdentityUser<int>
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public List<Article> Articles { get; set; }
	}
}