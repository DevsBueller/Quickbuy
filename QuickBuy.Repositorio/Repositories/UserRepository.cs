using QuickBuy.Dominio.Contracts;
using QuickBuy.Dominio.Entities;
using QuickBuy.Repositorio.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(QuickBuyContext quickBuyContext) : base(quickBuyContext)
		{
		}
	}
}
