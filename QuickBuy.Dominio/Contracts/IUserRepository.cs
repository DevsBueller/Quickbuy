using QuickBuy.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Contracts
{
	public interface IUserRepository: IBaseRepository<User>
	{
		User Get(string email, string password);
		User Get(string email);
	}
}
