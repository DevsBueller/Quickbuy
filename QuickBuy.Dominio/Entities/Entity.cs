using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Dominio.Entities
{
	public abstract class Entity
	{
	
		private List<string> ValidationMessages { get; set; } = new List<string>();
		
		public void ClearMessages()
		{
			ValidationMessages.Clear();
		}
		protected void AddCritic(string message)
		{
			ValidationMessages.Add(message);
		}
		public string getValidationMessage()
		{
			return string.Join(". ", ValidationMessages);
		}
		public abstract void Validate();

		public bool IsValid {
			get { return !ValidationMessages.Any(); }
		}

	}

	
}
