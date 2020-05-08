using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entities
{
	class User : Entity
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string FullName { get; set; }
		public ICollection<Order> Orders { get; set; } = new List<Order>();

		protected override void Validate()
		{
			throw new NotImplementedException();
		}
	}
}
