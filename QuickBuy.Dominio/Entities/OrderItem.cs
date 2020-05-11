using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entities
{
	public class OrderItem : Entity
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }

		public OrderItem()
		{
			
		}

		protected override void Validate()
		{
			if(ProductId == 0)
			{
				AddCritic("Não foi identificado qual a refência do produto");
			}
			if (Quantity== 0)
			{
				AddCritic("Quantidade não foi informada");
			}
		}
	}
}
