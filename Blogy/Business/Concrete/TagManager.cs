using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class TagManager : ITagService
	{
		private readonly ITagDal _tagDal;
		public TagManager(ITagDal tagDal)
		{
			_tagDal = tagDal;
		}

		public void Delete(Tag entity)
		{
			_tagDal.Delete(entity);
		}

		public Tag GetById(int id)
		{
			return _tagDal.GetById(id);
		}

        public List<Tag> GetAll()
		{
			return _tagDal.GetAll();
		}

		public void Create(Tag entity)
		{
			_tagDal.Create(entity);
		}

		public void Update(Tag entity)
		{
			_tagDal.Update(entity);
		}
		

	}
}