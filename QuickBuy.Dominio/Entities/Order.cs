using QuickBuy.Dominio.ValueObject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace QuickBuy.Dominio.Entities
{
	class Order : Entity
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int UserId { get; set; }
		public DateTime DatePrevDelivery { get; set; }
		public string CEP { get; set; }
		public string Estate  { get; set; }
		public string City { get; set; }
		public string Addres { get; set; }
		public int AddresNumber { get; set; }
		public int PaymentFormId { get; set; }
		public FormPayment PaymentForm { get; set; }
		public ICollection<OrderItem> OrdemItems { get; set; }

		protected override void Validate()
		{
			ClearMessages();
			if (!OrdemItems.Any())
			{
				AddCritic("Erro - O pedido não pode ficar sem nenhum item");
			
			}
			if (string.IsNullOrEmpty(CEP))
			{
				AddCritic("Erro - O Cep Deve estar Preenchido");
			}
		}
	}
}
