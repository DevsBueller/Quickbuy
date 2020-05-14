using QuickBuy.Dominio.Entities;
using QuickBuy.Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using QuickBuy.Repositorio.Context;

namespace QuickBuy.Repositorio.Repositories
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(QuickBuyContext quickBuyContext) : base(quickBuyContext)
		{
		}
	}
}
