using InventoryOrder.Models.entity;
using InventoryOrder.Models.intity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InventoryOrder.Models
{
    
       
public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // الجداول (Sets) الرئيسية
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<PaymentCustomer> PaymentCustomers { get; set; }
        public DbSet<PaymentSupplier> PaymentSuppliers { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }  // إضافة Warehouse

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // إعداد العلاقات
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Warehouse)
                .WithMany(w => w.Orders)
                .HasForeignKey(o => o.WarehouseID);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Warehouse)
                .WithMany(w => w.Products)
                .HasForeignKey(p => p.WarehouseID);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductID)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Purchases)
                .HasForeignKey(p => p.SupplierID);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Warehouse)
                .WithMany(w => w.Purchases)
                .HasForeignKey(p => p.WarehouseID);

            modelBuilder.Entity<PurchaseDetail>()
                .HasOne(pd => pd.Purchase)
                .WithMany(p => p.PurchaseDetails)
                .HasForeignKey(pd => pd.PurchaseID);

            modelBuilder.Entity<PurchaseDetail>()
                .HasOne(pd => pd.Product)
                .WithMany(p => p.PurchaseDetails)
                .HasForeignKey(pd => pd.ProductID);

            modelBuilder.Entity<PaymentCustomer>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Payments)
                .HasForeignKey(p => p.OrderID)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<PaymentSupplier>()
                .HasOne(p => p.Purchase)
                .WithMany(p => p.Payments)
                .HasForeignKey(p => p.PurchaseID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PaymentCustomer>()
              .HasOne(p => p.Customer)
              .WithMany(c => c.PaymentCustomers)
              .HasForeignKey(p => p.CustomerID); 

            modelBuilder.Entity<PaymentSupplier>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.PaymentSuppliers)
                .HasForeignKey(p => p.SupplierID)
                .OnDelete(DeleteBehavior.Restrict); 


            modelBuilder.Entity<PurchaseDetail>()
                 .HasOne(pd => pd.Purchase)
                 .WithMany(p => p.PurchaseDetails)
                 .HasForeignKey(pd => pd.PurchaseID)
                 .OnDelete(DeleteBehavior.NoAction);
        }

    }

}

