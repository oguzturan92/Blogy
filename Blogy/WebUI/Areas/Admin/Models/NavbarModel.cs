using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace WebUI.Areas.Admin.Models
{
    public class NavbarModel
    {
        public AppUser AppUser { get; set; }
        public int TotalBlogCount { get; set; }
    }
}