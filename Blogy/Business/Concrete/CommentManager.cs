using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class CommentManager : ICommentService
	{
		private readonly ICommentDal _commentDal;
		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}

		public void Delete(Comment entity)
		{
			_commentDal.Delete(entity);
		}

		public Comment GetById(int id)
		{
			return _commentDal.GetById(id);
		}

        public List<Comment> GetAll()
		{
			return _commentDal.GetAll();
		}

		public void Create(Comment entity)
		{
			_commentDal.Create(entity);
		}

		public void Update(Comment entity)
		{
			_commentDal.Update(entity);
		}
		

	}
}