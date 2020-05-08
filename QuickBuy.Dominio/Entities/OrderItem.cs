using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entities
{
	class OrderItem : Entity
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }

		protected override void Validate()
		{
			throw new NotImplementedException();
		}
	}
}
