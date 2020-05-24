using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Config
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(p => p.Id);
			// Builder utiliza o padrão fluent
			builder
				.Property(p => p.Name)
				.IsRequired()
 
				.HasColumnType("nvarchar(70)");
			builder
				.Property(p => p.Description)
				.IsRequired()
				.HasMaxLength(400);

			builder
				.Property(p => p.Price)
				.HasColumnType("decimal(19,4)")
				.IsRequired();
		


		}
	}
}
