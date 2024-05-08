using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IGenericService<T> where T : class
	{
		void Create(T entity);
		void Delete(T entity);
		void Update(T entity);
		List<T> GetAll();
		T GetById(int id);
	}
}