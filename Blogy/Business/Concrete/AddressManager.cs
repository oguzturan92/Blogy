using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class AddressManager : IAddressService
	{
		private readonly IAddressDal _aboutDal;
		public AddressManager(IAddressDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public void Delete(Address entity)
		{
			_aboutDal.Delete(entity);
		}

		public Address GetById(int id)
		{
			return _aboutDal.GetById(id);
		}

        public List<Address> GetAll()
		{
			return _aboutDal.GetAll();
		}

		public void Create(Address entity)
		{
			_aboutDal.Create(entity);
		}

		public void Update(Address entity)
		{
			_aboutDal.Update(entity);
		}
		

	}
}