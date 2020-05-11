using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Config
{
	class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.HasKey(o => o.Id);
			builder
				.Property(o => o.Date)
				.IsRequired();
			builder
				.Property(o => o.DatePrevDelivery)
				.IsRequired();
			builder
				.Property(o => o.CEP)
				.IsRequired()
				.HasMaxLength(10);
			builder.Property(o => o.City)
				.IsRequired()
				.HasMaxLength(100);
			builder.Property(o => o.State)
				.IsRequired()
				.HasMaxLength(100);
			builder.Property(o => o.Addres)
				.IsRequired()
				.HasMaxLength(100);
			builder.Property(o => o.AddresNumber)
				.IsRequired();
			



		}
	}
}
