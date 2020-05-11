using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entities
{
	public class Product : Entity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description  { get; set; }
		public decimal Price { get; set; }

		protected override void Validate()
		{
			throw new NotImplementedException();
		}
	}
}
