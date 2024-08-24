using System;
using System.Collections.Generic;
using LINQ.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LINQ.DAL;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Phim> Phims { get; set; }

    public virtual DbSet<TheLoai> TheLoais { get; set; }

    public virtual DbSet<TheLoaiCuaPhim> TheLoaiCuaPhims { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=powa;Database=QuanLiPhim;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Phim>(entity =>
        {
            entity.HasKey(e => e.PhimId).HasName("PK__Phim__587830C5E8CE527C");

            entity.ToTable("Phim");

            entity.Property(e => e.PhimId).HasColumnName("PhimID");
            entity.Property(e => e.DaoDien).HasMaxLength(100);
            entity.Property(e => e.TenPhim).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(1);
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.TheLoaiId).HasName("PK__TheLoai__241C3B3A743E5B1C");

            entity.ToTable("TheLoai");

            entity.Property(e => e.TheLoaiId).HasColumnName("TheLoaiID");
            entity.Property(e => e.TenTheLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<TheLoaiCuaPhim>(entity =>
        {
            entity.HasKey(e => new { e.PhimId, e.TheLoaiId }).HasName("PK__TheLoaiC__EA39F376261E1699");

            entity.ToTable("TheLoaiCuaPhim");

            entity.Property(e => e.PhimId).HasColumnName("PhimID");
            entity.Property(e => e.TheLoaiId).HasColumnName("TheLoaiID");
            entity.Property(e => e.TrangThai).HasDefaultValue(1);

            entity.HasOne(d => d.Phim).WithMany(p => p.TheLoaiCuaPhims)
                .HasForeignKey(d => d.PhimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TheLoaiCu__PhimI__3D5E1FD2");

            entity.HasOne(d => d.TheLoai).WithMany(p => p.TheLoaiCuaPhims)
                .HasForeignKey(d => d.TheLoaiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TheLoaiCu__TheLo__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
