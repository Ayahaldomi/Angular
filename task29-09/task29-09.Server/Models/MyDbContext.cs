﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace task29_09.Server.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<SubService> SubServices { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserSubscription> UserSubscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NNTQNVK;Database=task1;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Carts__51BCD797B855CFFE");

            entity.HasIndex(e => e.UserId, "UQ__Carts__1788CCADD255CD90").IsUnique();

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.UserId)
                .HasConstraintName("FK_UserCart");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__CartItem__488B0B2A17776935");

            entity.HasIndex(e => new { e.CartId, e.ProductId }, "UQ__CartItem__9AFC1BF81D630AD4").IsUnique();

            entity.Property(e => e.CartItemId).HasColumnName("CartItemID");
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK_Cart");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Product");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B4FFDFA92");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryImage).IsUnicode(false);
            entity.Property(e => e.CategoryName).IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF801D4AC6");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__productI__5DCAEF64");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__UserID__5CD6CB2B");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6EDE1C4527D");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductImage).IsUnicode(false);
            entity.Property(e => e.ProductName).IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__398D8EEE");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__4550733F3943BA9B");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.ServiceDescription).HasMaxLength(500);
            entity.Property(e => e.ServiceName).HasMaxLength(50);
        });

        modelBuilder.Entity<SubService>(entity =>
        {
            entity.HasKey(e => e.SubServiceId).HasName("PK__subServi__C5C51FFA151EFC3E");

            entity.ToTable("subService");

            entity.Property(e => e.SubServiceId).HasColumnName("subServiceID");
            entity.Property(e => e.ServiceId).HasColumnName("serviceId");
            entity.Property(e => e.SubServiceDescription).HasMaxLength(500);
            entity.Property(e => e.SubServiceName).HasMaxLength(50);

            entity.HasOne(d => d.Service).WithMany(p => p.SubServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__subServic__servi__71D1E811");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.SubscriptionId).HasName("PK__subscrip__4A0F55C737C5014B");

            entity.ToTable("subscription");

            entity.Property(e => e.SubscriptionId).HasColumnName("subscriptionID");
            entity.Property(e => e.SubscriptionAmount).HasColumnName("subscriptionAmount");
            entity.Property(e => e.SubscriptionDescription).HasColumnName("subscriptionDescription");
            entity.Property(e => e.SubscriptionName)
                .HasMaxLength(150)
                .HasColumnName("subscriptionName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC941FFB23");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.Role });

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Role).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_User");
        });

        modelBuilder.Entity<UserSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserSubs__3213E83F18B6943A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.SubServiceId).HasColumnName("subServiceID");
            entity.Property(e => e.SubscriptionId).HasColumnName("subscriptionID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Subscription).WithMany(p => p.UserSubscriptions)
                .HasForeignKey(d => d.SubscriptionId)
                .HasConstraintName("FK_Subscription");

            entity.HasOne(d => d.User).WithMany(p => p.UserSubscriptions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
