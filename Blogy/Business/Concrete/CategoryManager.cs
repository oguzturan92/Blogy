using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryDal _categoryDal;
		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public void Delete(Category entity)
		{
			_categoryDal.Delete(entity);
		}

		public Category GetById(int id)
		{
			return _categoryDal.GetById(id);
		}

		public List<Category> GetAll()
		{
			return _categoryDal.GetAll();
		}

		public void Create(Category entity)
		{
			_categoryDal.Create(entity);
		}

		public void Update(Category entity)
		{
			_categoryDal.Update(entity);
		}
		
		public List<Category> GetCategoriesAndCounts()
		{
			return _categoryDal.GetCategoriesAndCounts();
		}

		public List<Category> GetCategoriesAndCounts(int userId)
		{
			return _categoryDal.GetCategoriesAndCounts(userId);
		}

	}
}