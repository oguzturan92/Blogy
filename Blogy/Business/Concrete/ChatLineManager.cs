using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class ChatLineManager : IChatLineService
	{
		private readonly IChatLineDal _chatDal;
		public ChatLineManager(IChatLineDal chatDal)
		{
			_chatDal = chatDal;
		}

		public void Delete(ChatLine entity)
		{
			_chatDal.Delete(entity);
		}

		public ChatLine GetById(int id)
		{
			return _chatDal.GetById(id);
		}

        public List<ChatLine> GetAll()
		{
			return _chatDal.GetAll();
		}

		public void Create(ChatLine entity)
		{
			_chatDal.Create(entity);
		}

		public void Update(ChatLine entity)
		{
			_chatDal.Update(entity);
		}
		

	}
}