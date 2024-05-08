using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Tag
    {
      public int TagId { get; set; }
      public string TagTitle { get; set; }
      public List<Article> Articles { get; set; }
    }
}