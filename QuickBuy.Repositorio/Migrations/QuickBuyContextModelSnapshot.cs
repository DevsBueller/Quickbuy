﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickBuy.Repositorio.Context;

namespace QuickBuy.Repositorio.Migrations
{
    [DbContext(typeof(QuickBuyContext))]
    partial class QuickBuyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("QuickBuy.Dominio.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("AddresNumber");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DatePrevDelivery");

                    b.Property<int>("PaymentFormId");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PaymentFormId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("FileName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(19,4)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Administrator");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuickBuy.Dominio.ValueObject.FormPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Paymentform");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Forma de Pagamento Boleto",
                            Name = "Boleto"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Cartão de Crédito",
                            Name = "Cartão de Crédito"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Forma de Depósito",
                            Name = "Depósito"
                        });
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entities.Order", b =>
                {
                    b.HasOne("QuickBuy.Dominio.ValueObject.FormPayment", "PaymentForm")
                        .WithMany()
                        .HasForeignKey("PaymentFormId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuickBuy.Dominio.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entities.OrderItem", b =>
                {
                    b.HasOne("QuickBuy.Dominio.Entities.Order")
                        .WithMany("OrdemItems")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
