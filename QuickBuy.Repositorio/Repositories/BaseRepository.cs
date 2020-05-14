using QuickBuy.Dominio.Contracts;
using QuickBuy.Dominio.Entities;
using QuickBuy.Repositorio.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Repositorio
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected readonly QuickBuyContext QuickBuyContext;

		public BaseRepository(QuickBuyContext quickBuyContext)
		{
			QuickBuyContext = quickBuyContext;
		}
		public void Add(T entity)
		{
			QuickBuyContext.Set<T>().Add(entity);
			QuickBuyContext.SaveChanges();
		}
		public IEnumerable<T> GetAll()
		{
			return QuickBuyContext.Set<T>().ToList();
			
		}

		public T GetById(int id)
		{
			return QuickBuyContext.Set<T>().Find(id);
		}

		public void Remove(T entity)
		{
			QuickBuyContext.Set<T>().Remove(entity);
			QuickBuyContext.SaveChanges();
		}

		public void Update(T entity)
		{
			QuickBuyContext.Set<T>().Add(entity);
			QuickBuyContext.SaveChanges();
		}
		public void Dispose()
		{
			QuickBuyContext.Dispose();
		}
	}
}
