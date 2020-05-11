using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace QuickBuy.Dominio.Entities
{
	public 
		class User : Entity
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string FullName { get; set; }
		public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

		protected override void Validate()
		{
			if (string.IsNullOrEmpty(Email))
			{
				AddCritic("Emai não foi informado");
			}
			if (string.IsNullOrEmpty(Password))
			{
				AddCritic("Senha não foi informada");   
			}
		}
	}
}
