using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Inventory_system.Models;

public partial class InventorySystemContext : DbContext
{
    //private IConfiguration _configuration;

    public InventorySystemContext()
    {
    }

    public InventorySystemContext(DbContextOptions<InventorySystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SubVariant> SubVariants { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Variant> Variants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer("Data Source=LAPTOP-5M9L3AJN\\MSSQLSERVER02;Initial Catalog=InventorySystem;Integrated Security=True;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC071DAF48D1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Hsncode)
                .HasMaxLength(100)
                .HasColumnName("HSNCode");
            entity.Property(e => e.IsFavourite).HasDefaultValue(false);
            entity.Property(e => e.ProductCode).HasMaxLength(100);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.TotalStock)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CreatedUserNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CreatedUser)
                .HasConstraintName("FK__Products__Create__398D8EEE");
        });

        modelBuilder.Entity<SubVariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubVaria__3214EC07ADA69AB0");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Stock)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubVariantName).HasMaxLength(100);

            entity.HasOne(d => d.Variant).WithMany(p => p.SubVariants)
                .HasForeignKey(d => d.VariantId)
                .HasConstraintName("FK__SubVarian__Varia__4222D4EF");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07ADFBCF5A");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<Variant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Variants__3214EC07FB07BE13");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.VariantName).HasMaxLength(100);

            entity.HasOne(d => d.Product).WithMany(p => p.Variants)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Variants__Produc__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
