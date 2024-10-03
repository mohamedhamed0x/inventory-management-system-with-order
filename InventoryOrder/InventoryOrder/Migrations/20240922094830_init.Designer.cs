﻿// <auto-generated />
using System;
using InventoryOrder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryOrder.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240922094830_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InventoryOrder.Models.intity.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<decimal>("AccountBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WarehouseID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("WarehouseID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailID"));

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsCustomerPayment")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int?>("OrderID1")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PurchaseID")
                        .HasColumnType("int");

                    b.Property<int?>("PurchaseID1")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.HasIndex("OrderID");

                    b.HasIndex("OrderID1");

                    b.HasIndex("PurchaseID");

                    b.HasIndex("PurchaseID1");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WarehouseID")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("WarehouseID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Purchase", b =>
                {
                    b.Property<int>("PurchaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseID"));

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WarehouseID")
                        .HasColumnType("int");

                    b.HasKey("PurchaseID");

                    b.HasIndex("SupplierID");

                    b.HasIndex("WarehouseID");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.PurchaseDetail", b =>
                {
                    b.Property<int>("PurchaseDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseDetailID"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("PurchaseDetailID");

                    b.HasIndex("ProductID");

                    b.HasIndex("PurchaseID");

                    b.ToTable("PurchaseDetails");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"));

                    b.Property<decimal>("AccountBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Warehouse", b =>
                {
                    b.Property<int>("WarehouseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseID"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WarehouseID");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Order", b =>
                {
                    b.HasOne("InventoryOrder.Models.intity.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryOrder.Models.intity.Warehouse", "Warehouse")
                        .WithMany("Orders")
                        .HasForeignKey("WarehouseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.OrderDetail", b =>
                {
                    b.HasOne("InventoryOrder.Models.intity.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InventoryOrder.Models.intity.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Payment", b =>
                {
                    b.HasOne("InventoryOrder.Models.intity.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("InventoryOrder.Models.intity.Order", null)
                        .WithMany("Payments")
                        .HasForeignKey("OrderID1");

                    b.HasOne("InventoryOrder.Models.intity.Purchase", "Purchase")
                        .WithMany()
                        .HasForeignKey("PurchaseID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("InventoryOrder.Models.intity.Purchase", null)
                        .WithMany("Payments")
                        .HasForeignKey("PurchaseID1");

                    b.Navigation("Order");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Product", b =>
                {
                    b.HasOne("InventoryOrder.Models.intity.Warehouse", "Warehouse")
                        .WithMany("Products")
                        .HasForeignKey("WarehouseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Purchase", b =>
                {
                    b.HasOne("InventoryOrder.Models.intity.Supplier", "Supplier")
                        .WithMany("Purchases")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryOrder.Models.intity.Warehouse", "Warehouse")
                        .WithMany("Purchases")
                        .HasForeignKey("WarehouseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.PurchaseDetail", b =>
                {
                    b.HasOne("InventoryOrder.Models.intity.Product", "Product")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryOrder.Models.intity.Purchase", "Purchase")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("PurchaseID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Order", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("PurchaseDetails");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Purchase", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("PurchaseDetails");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Supplier", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("InventoryOrder.Models.intity.Warehouse", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Products");

                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
