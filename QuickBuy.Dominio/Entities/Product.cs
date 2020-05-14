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

		public override void Validate()
		{
			if (string.IsNullOrEmpty(Name))
				AddCritic("Nome do produto não foi informado");

			if (string.IsNullOrEmpty(Description))
				AddCritic("Descrição não foi informado");

		}
	}
}
