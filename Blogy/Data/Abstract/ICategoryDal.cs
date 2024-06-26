using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Data.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        List<Category> GetCategoriesAndCounts();
        List<Category> GetCategoriesAndCounts(int userId);
    }
}