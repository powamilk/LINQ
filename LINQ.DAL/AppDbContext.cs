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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=POWWA\\MSSQLSERVER01;Database=QuanLiPhim1;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Phim>(entity =>
        {
            entity.HasKey(e => e.PhimId).HasName("PK__Phim__587830C5DC2EAAFB");

            entity.ToTable("Phim");

            entity.Property(e => e.PhimId).HasColumnName("PhimID");
            entity.Property(e => e.DaoDien).HasMaxLength(100);
            entity.Property(e => e.TenPhim).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(1);

            entity.HasMany(d => d.TheLoais).WithMany(p => p.Phims)
                .UsingEntity<Dictionary<string, object>>(
                    "TheLoaiCuaPhim",
                    r => r.HasOne<TheLoai>().WithMany()
                        .HasForeignKey("TheLoaiId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TheLoaiCu__TheLo__3D5E1FD2"),
                    l => l.HasOne<Phim>().WithMany()
                        .HasForeignKey("PhimId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TheLoaiCu__PhimI__3C69FB99"),
                    j =>
                    {
                        j.HasKey("PhimId", "TheLoaiId").HasName("PK__TheLoaiC__EA39F376CCE182AB");
                        j.ToTable("TheLoaiCuaPhim");
                        j.IndexerProperty<int>("PhimId").HasColumnName("PhimID");
                        j.IndexerProperty<int>("TheLoaiId").HasColumnName("TheLoaiID");
                    });
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.TheLoaiId).HasName("PK__TheLoai__241C3B3AB773536A");

            entity.ToTable("TheLoai");

            entity.Property(e => e.TheLoaiId).HasColumnName("TheLoaiID");
            entity.Property(e => e.TenTheLoai).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
