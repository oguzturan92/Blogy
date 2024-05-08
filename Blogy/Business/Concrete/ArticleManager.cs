using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class ArticleManager : IArticleService
	{
		private readonly IArticleDal _articleDal;
		public ArticleManager(IArticleDal articleDal)
		{
			_articleDal = articleDal;
		}

        public List<Article> GetArticlesByWriter(int id)
        {
            return _articleDal.GetArticlesByWriter(id);
        }

        public List<Article> GetArticleWithWriter()
        {
            return _articleDal.GetArticleWithWriter();
        }

        public Article GetArticleAndWriter(int id)
        {
            return _articleDal.GetArticleAndWriter(id);
        }

        public void Delete(Article entity)
		{
			_articleDal.Delete(entity);
		}

		public Article GetById(int id)
		{
			return _articleDal.GetById(id);
		}

		public List<Article> GetAll()
		{
			return _articleDal.GetAll();
		}

		public void Create(Article entity)
		{
			_articleDal.Create(entity);
		}

		public void Update(Article entity)
		{
		    _articleDal.Update(entity);
		}
	}
}