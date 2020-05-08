using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entities
{
	public class Product : Entity
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao  { get; set; }
		public decimal MyProperty { get; set; }

		protected override void Validate()
		{
			throw new NotImplementedException();
		}
	}
}
