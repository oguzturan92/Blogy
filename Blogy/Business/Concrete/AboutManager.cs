using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class AboutManager : IAboutService
	{
		private readonly IAboutDal _aboutDal;
		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public void Delete(About entity)
		{
			_aboutDal.Delete(entity);
		}

		public About GetById(int id)
		{
			return _aboutDal.GetById(id);
		}

        public List<About> GetAll()
		{
			return _aboutDal.GetAll();
		}

		public void Create(About entity)
		{
			_aboutDal.Create(entity);
		}

		public void Update(About entity)
		{
			_aboutDal.Update(entity);
		}
		

	}
}