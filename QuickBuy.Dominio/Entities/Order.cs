using QuickBuy.Dominio.ValueObject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace QuickBuy.Dominio.Entities
{
	class Order
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int UserId { get; set; }
		public DateTime DatePrevDelivery { get; set; }
		public string Cep { get; set; }
		public string Estate  { get; set; }
		public string City { get; set; }
		public string Addres { get; set; }
		public int AddresNumber { get; set; }
		public int PaymentFormId { get; set; }
		public FormPayment PaymentForm { get; set; }
		public ICollection<OrderItem> OrdemItems { get; set; }
	}
}
