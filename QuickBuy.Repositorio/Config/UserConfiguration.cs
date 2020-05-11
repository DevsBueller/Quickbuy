using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QuickBuy.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Config
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u=> u.Id);
			// Builder utilizando o padrão fluent
			builder
				.Property(u => u.Email)
				.IsRequired()
				.HasMaxLength(50);
			builder
				.Property(u => u.Password)
				.IsRequired()
				.HasMaxLength(400);
				
			builder
				.Property(u => u.Name)
				.IsRequired()			
				.HasColumnType("varchar(50)");
			builder
				.Property(u => u.FullName)
				.IsRequired()
				.HasColumnType("varchar(50)");
			builder.HasMany(u => u.Orders)
				.WithOne(p => p.User);
			



		}
	}
}
