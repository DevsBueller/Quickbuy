using QuickBuy.Dominio.Contracts;
using QuickBuy.Dominio.Entities;
using QuickBuy.Repositorio.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Repositories
{
	public class OrderRepository : BaseRepository<Order>, IOrderRepository
	{
		public OrderRepository(QuickBuyContext quickBuyContext) : base(quickBuyContext)
		{
		}
	}
}
