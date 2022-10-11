using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace smg_erp.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<PersonDocument> PersonDocuments { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductMedium> ProductMedia { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Tenant> Tenants { get; set; } = null!;
        public virtual DbSet<TenantSecrect> TenantSecrects { get; set; } = null!;
        public virtual DbSet<Token> Tokens { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.OrderId });

                entity.Property(e => e.TenantId).HasColumnName("tenant_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.DateCanceled)
                    .HasColumnType("datetime")
                    .HasColumnName("date_canceled");

                entity.Property(e => e.DateClosed)
                    .HasColumnType("datetime")
                    .HasColumnName("date_closed");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsCanceled)
                    .HasColumnName("is_canceled")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsClosed)
                    .HasColumnName("is_closed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => new { d.TenantId, d.PersonId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_People");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.OrderId, e.ItemId });

                entity.Property(e => e.TenantId).HasColumnName("tenant_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => new { d.TenantId, d.OrderId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItems_Orders");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.PersonId });

                entity.HasIndex(e => e.DiscordUserId, "Index_People_discord_user_id");

                entity.Property(e => e.TenantId).HasColumnName("tenant_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscordUserId).HasColumnName("discord_user_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PersonDocument>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.PersonId, e.DocumentId });

                entity.Property(e => e.TenantId).HasColumnName("tenant_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.DocumentId).HasColumnName("document_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("url");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonDocuments)
                    .HasForeignKey(d => new { d.TenantId, d.PersonId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonDocuments_People");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.ProductId });

                entity.Property(e => e.TenantId).HasColumnName("tenant_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("price");

                entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => new { d.TenantId, d.ProductTypeId })
                    .HasConstraintName("FK_Products_ProductTypes");
            });

            modelBuilder.Entity<ProductMedium>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.ProductId, e.MediaId });

                entity.Property(e => e.TenantId).HasColumnName("tenant_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.MediaId).HasColumnName("media_id");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("url");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductMedia)
                    .HasForeignKey(d => new { d.TenantId, d.ProductId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductMedia_Products");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.ProductTypeId });

                entity.Property(e => e.TenantId).HasColumnName("tenant_id");

                entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.ProfileId });

                entity.Property(e => e.TenantId).HasColumnName("tenant_id");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.ProfileName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("profile_name");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.Property(e => e.TenantId)
                    .ValueGeneratedNever()
                    .HasColumnName("tenant_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TenantSecrect>(entity =>
            {
                entity.HasKey(e => e.TenantId);

                entity.ToTable("TenantSecrect");

                entity.Property(e => e.TenantId)
                    .ValueGeneratedNever()
                    .HasColumnName("tenant_id");

                entity.Property(e => e.Secrect)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("secrect");

                entity.HasOne(d => d.Tenant)
                    .WithOne(p => p.TenantSecrect)
                    .HasForeignKey<TenantSecrect>(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TenantSecrect_Tenants");
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.UserId, e.TokenId });

                entity.HasIndex(e => e.Token1, "Index_Tokens_token");

                entity.Property(e => e.TenantId).HasColumnName("tenant_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.TokenId).HasColumnName("token_id");

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expire_date");

                entity.Property(e => e.LoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("login_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Token1)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tokens)
                    .HasForeignKey(d => new { d.TenantId, d.UserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tokens_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.UserId });

                entity.Property(e => e.TenantId).HasColumnName("tenant_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.Hash)
                    .HasMaxLength(1)
                    .HasColumnName("hash")
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nickname");

                entity.Property(e => e.Salt)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("salt");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.ProfileId, e.UserId });

                entity.ToTable("UserProfile");

                entity.Property(e => e.TenantId).HasColumnName("tenant_id");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => new { d.TenantId, d.ProfileId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProfile_Profiles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => new { d.TenantId, d.UserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProfile_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
