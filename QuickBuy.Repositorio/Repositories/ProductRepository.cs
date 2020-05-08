using QuickBuy.Dominio.Entities;
using QuickBuy.Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Repositories
{
	class ProductRepository: BaseRepository<Product>, IProductRepository
	{
	}
}
