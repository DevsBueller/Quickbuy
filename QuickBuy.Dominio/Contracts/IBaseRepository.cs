using QuickBuy.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Contracts
{
	public interface IBaseRepository<T>: IDisposable where T:class
	{
		T GetById(int id);
		IEnumerable<T> GetAll();
		void Update(T entity);
		void Remove(T entity);

	}
}
