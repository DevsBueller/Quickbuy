using QuickBuy.Dominio.ValueObject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace QuickBuy.Dominio.Entities
{
	public class Order : Entity
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
		public DateTime DatePrevDelivery { get; set; }
		public string CEP { get; set; }
		public string State  { get; set; }
		public string City { get; set; }
		public string Addres { get; set; }
		public int AddresNumber { get; set; }
		public int PaymentFormId { get; set; }
		public virtual FormPayment PaymentForm { get; set; }
		public virtual ICollection<OrderItem> OrdemItems { get; set; }

		public override void Validate()
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
			if (PaymentFormId == 0)
			{
				AddCritic("Erro - Não foi informada a forma de pagamento");
			}
		}
	}
}
