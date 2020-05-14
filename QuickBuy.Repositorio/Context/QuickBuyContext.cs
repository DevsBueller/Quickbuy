using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entities;
using QuickBuy.Dominio.ValueObject;
using QuickBuy.Repositorio.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Context
{
	public class QuickBuyContext: DbContext
	{
	

		public DbSet<User> Users { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order>Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<FormPayment> Paymentform { get; set; }
		public QuickBuyContext (DbContextOptions options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Classes de mapeamento 
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
			modelBuilder.ApplyConfiguration(new PaymentFormConfiguration());
			modelBuilder.Entity<FormPayment>().HasData(
				   new FormPayment(1, "Boleto", "Forma de Pagamento Boleto"),
				   new FormPayment(2, "Cartão de Crédito", "Cartão de Crédito"),
				   new FormPayment(3, "Depósito", "Forma de Depósito")

				   );
			base.OnModelCreating(modelBuilder);
		}


	}
}
