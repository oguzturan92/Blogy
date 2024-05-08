using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class ChatManager : IChatService
	{
		private readonly IChatDal _chatLineDal;
		public ChatManager(IChatDal chatLineDal)
		{
			_chatLineDal = chatLineDal;
		}

		public void Delete(Chat entity)
		{
			_chatLineDal.Delete(entity);
		}

		public Chat GetById(int id)
		{
			return _chatLineDal.GetById(id);
		}

        public List<Chat> GetAll()
		{
			return _chatLineDal.GetAll();
		}

		public void Create(Chat entity)
		{
			_chatLineDal.Create(entity);
		}

		public void Update(Chat entity)
		{
			_chatLineDal.Update(entity);
		}
		

	}
}