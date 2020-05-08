using QuickBuy.Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		public BaseRepository()
		{
		}

		public IEnumerable<T> GetAll()
		{
			throw new NotImplementedException();
		}

		public T GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Remove(T entity)
		{
			throw new NotImplementedException();
		}

		public void Update(T entity)
		{
			throw new NotImplementedException();
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
