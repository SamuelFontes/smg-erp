﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Products.Domain.Model.Person;
using Products.Domain.Model.Product;
using Products.Domain.Model.ProductType;
using Products.Domain.Model.Tenant;

namespace Products.Infrastructure.Context;

public partial class NightDbContext : DbContext
{
    public NightDbContext()
    {
    }

    public NightDbContext(DbContextOptions<NightDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    // put the connection string below if you want to use migrations
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => new { e.TenantId, e.PersonId }).HasName("PK_TenantId_PersonId");

            entity.ToTable("Person");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(24);
            entity.Property(e => e.LastName).HasMaxLength(24);
            entity.Property(e => e.Name).HasMaxLength(24);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.TenantId }).HasName("PK_ProductId_TenantId");

            entity.ToTable("Product");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(120);
            entity.Property(e => e.Name).HasMaxLength(60);
            entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => new { e.ProductTypeId, e.TenantId }).HasName("PK_ProductTypeId_TenantId");

            entity.ToTable("ProductType");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(120);
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.TenantId).HasName("PK_TenantId");

            entity.ToTable("Tenant");

            entity.Property(e => e.TenantId).ValueGeneratedNever();
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}