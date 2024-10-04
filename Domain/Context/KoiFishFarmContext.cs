using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context;

public partial class KoiFishFarmContext : DbContext
{
    public KoiFishFarmContext(DbContextOptions<KoiFishFarmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Batch> Batches { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<DeliveryCompany> DeliveryCompanies { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Fish> Fish { get; set; }

    public virtual DbSet<FishCategory> FishCategories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Batch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Batch__3214EC072CF2BA22");

            entity.ToTable("Batch");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);

            entity.HasOne(d => d.Creator).WithMany(p => p.Batches)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Batch__CreatorId__5165187F");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07AA8A9CE7");

            entity.ToTable("Category");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<DeliveryCompany>(entity =>
        {
            entity.ToTable("DeliveryCompany");

            entity.HasIndex(e => e.Id, "UQ__Delivery__3214EC0668461A53").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(256);
            entity.Property(e => e.Status).HasMaxLength(256);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.ToTable("Driver");

            entity.HasIndex(e => e.Id, "UQ__Driver__3214EC06C0120EC7").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(256);
            entity.Property(e => e.Plates).HasMaxLength(256);
            entity.Property(e => e.Status).HasMaxLength(256);

            entity.HasOne(d => d.DeliveryCompany).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.DeliveryCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Driver__Delivery__5EBF139D");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3214EC07D3181CDB");

            entity.ToTable("Feedback");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__Custom__6B24EA82");

            entity.HasOne(d => d.Order).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__OrderI__6A30C649");
        });

        modelBuilder.Entity<Fish>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fish__3214EC07802D622F");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Origin).HasMaxLength(256);
            entity.Property(e => e.Status).HasMaxLength(256);

            entity.HasOne(d => d.Batch).WithMany(p => p.Fish)
                .HasForeignKey(d => d.BatchId)
                .HasConstraintName("FK__Fish__BatchId__5535A963");

            entity.HasOne(d => d.Creator).WithMany(p => p.Fish)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fish__CreatorId__5441852A");
        });

        modelBuilder.Entity<FishCategory>(entity =>
        {
            entity.HasKey(e => new { e.FishId, e.CategoryId }).HasName("PK__FishCate__59BAC87974A8D679");

            entity.ToTable("FishCategory");

            entity.HasIndex(e => e.Id, "UQ__FishCate__3214EC06C75560CC").IsUnique();

            entity.HasOne(d => d.Category).WithMany(p => p.FishCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FishCateg__Categ__59FA5E80");

            entity.HasOne(d => d.Fish).WithMany(p => p.FishCategories)
                .HasForeignKey(d => d.FishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FishCateg__FishI__59063A47");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC07298B752A");

            entity.ToTable("Order");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(256);
            entity.Property(e => e.Receiver).HasMaxLength(256);
            entity.Property(e => e.Status).HasMaxLength(256);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__CustomerI__619B8048");

            entity.HasOne(d => d.Driver).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK__Order__DriverId__628FA481");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07E38535F7");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Batch).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.BatchId)
                .HasConstraintName("FK__OrderDeta__Batch__6754599E");

            entity.HasOne(d => d.Fish).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.FishId)
                .HasConstraintName("FK__OrderDeta__FishI__66603565");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__656C112C");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC072FB8D5B4");

            entity.ToTable("Role");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0736631AC7");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E4BD310B26").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Password).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(256);
            entity.Property(e => e.Status).HasMaxLength(256);
            entity.Property(e => e.Username).HasMaxLength(256);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__RoleId__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
