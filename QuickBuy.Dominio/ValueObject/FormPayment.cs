using QuickBuy.Dominio.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.ValueObject
{
	public class FormPayment
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public FormPayment(int id, string name, string description)
		{
			Id = id;
			Name = name;
			Description = description;
		}

		public bool IsBillet
		{
			get { return Id == (int)TypePaymentForm.Billet; }
		}
		public bool IsCreditCard
		{
			get { return Id == (int)TypePaymentForm.CreditCard; }
		}
		public bool IsDeposit
		{
			get { return Id == (int)TypePaymentForm.Deposit; }
		}
		public bool NotDefined
		{
			get { return Id == (int)TypePaymentForm.NotDefined; }
		}

	}
}
