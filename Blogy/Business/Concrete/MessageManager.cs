using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class MessageManager : IMessageService
	{
		private readonly IMessageDal _messageDal;
		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public void Delete(Message entity)
		{
			_messageDal.Delete(entity);
		}

		public Message GetById(int id)
		{
			return _messageDal.GetById(id);
		}

        public List<Message> GetAll()
		{
			return _messageDal.GetAll();
		}

		public void Create(Message entity)
		{
			_messageDal.Create(entity);
		}

		public void Update(Message entity)
		{
			_messageDal.Update(entity);
		}
		

	}
}