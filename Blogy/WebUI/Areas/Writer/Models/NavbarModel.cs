using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace WebUI.Areas.Writer.Models
{
    public class NavbarModel
    {
        public AppUser AppUser { get; set; }
        public int TotalBlogCount { get; set; }
    }
}