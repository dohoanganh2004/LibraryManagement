using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Models;

public partial class ELibraryContext : DbContext
{
    public ELibraryContext()
    {
    }

    public ELibraryContext(DbContextOptions<ELibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DocGium> DocGia { get; set; }

    public virtual DbSet<LogHoatDong> LogHoatDongs { get; set; }

    public virtual DbSet<MuonTraSach> MuonTraSaches { get; set; }

    public virtual DbSet<MuonTraSachChiTiet> MuonTraSachChiTiets { get; set; }

    public virtual DbSet<NgonNgu> NgonNgus { get; set; }

    public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<QuyenHan> QuyenHans { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<TacGium> TacGia { get; set; }

    public virtual DbSet<TheLoai> TheLoais { get; set; }

    public virtual DbSet<TheThuVien> TheThuViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7KQPR9J;uid=sa;password=123456;database= eLibrary;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocGium>(entity =>
        {
            entity.HasKey(e => e.MaDocGia).HasName("PK__DocGia__F165F94543C4514B");

            entity.HasIndex(e => e.SoDienThoai, "UQ__DocGia__0389B7BD6CFE46FC").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__DocGia__A9D10534D411E2FE").IsUnique();

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenDocGia).HasMaxLength(100);
        });

        modelBuilder.Entity<LogHoatDong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LogHoatD__3214EC2754039EA3");

            entity.ToTable("LogHoatDong");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BangLienQuan).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(1000);
            entity.Property(e => e.HanhDong).HasMaxLength(255);
            entity.Property(e => e.KhoaChinh).HasMaxLength(50);
            entity.Property(e => e.LoaiNguoiDung).HasMaxLength(20);
            entity.Property(e => e.ThoiGian)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<MuonTraSach>(entity =>
        {
            entity.HasKey(e => e.MaMuonSach).HasName("PK__MuonTraS__DCE29B5C121F7FB5");

            entity.ToTable("MuonTraSach");

            entity.Property(e => e.GhiChu).HasMaxLength(1500);
            entity.Property(e => e.MaThe).HasMaxLength(10);

            entity.HasOne(d => d.MaTheNavigation).WithMany(p => p.MuonTraSaches)
                .HasForeignKey(d => d.MaThe)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__MuonTraSa__MaThe__656C112C");
        });

        modelBuilder.Entity<MuonTraSachChiTiet>(entity =>
        {
            entity.HasKey(e => new { e.MaMuonSach, e.MaSach }).HasName("PK__MuonTraS__17C1CC1E1280F892");

            entity.ToTable("MuonTraSachChiTiet");

            entity.Property(e => e.MaSach).HasMaxLength(10);
            entity.Property(e => e.TrangThai).HasMaxLength(100);

            entity.HasOne(d => d.MaMuonSachNavigation).WithMany(p => p.MuonTraSachChiTiets)
                .HasForeignKey(d => d.MaMuonSach)
                .HasConstraintName("FK__MuonTraSa__MaMuo__68487DD7");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.MuonTraSachChiTiets)
                .HasForeignKey(d => d.MaSach)
                .HasConstraintName("FK__MuonTraSa__MaSac__693CA210");
        });

        modelBuilder.Entity<NgonNgu>(entity =>
        {
            entity.HasKey(e => e.MaNgonNgu).HasName("PK__NgonNgu__131924EED597FA3B");

            entity.ToTable("NgonNgu");

            entity.HasIndex(e => e.TenNgonNgu, "UQ__NgonNgu__1C2FF7099303BF82").IsUnique();

            entity.Property(e => e.TenNgonNgu).HasMaxLength(100);
        });

        modelBuilder.Entity<NhaXuatBan>(entity =>
        {
            entity.HasKey(e => e.MaNxb).HasName("PK__NhaXuatB__3A19482CEF713958");

            entity.ToTable("NhaXuatBan");

            entity.HasIndex(e => e.TenNxb, "UQ__NhaXuatB__CCE3868D9DBC917B").IsUnique();

            entity.Property(e => e.MaNxb).HasColumnName("MaNXB");
            entity.Property(e => e.TenNxb)
                .HasMaxLength(100)
                .HasColumnName("TenNXB");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47AB8D80DE");

            entity.ToTable("NhanVien");

            entity.HasIndex(e => e.HoVaTen, "UQ__NhanVien__01A2CE8F44BE25B1").IsUnique();

            entity.HasIndex(e => e.SoDienThoai, "UQ__NhanVien__0389B7BD47774E82").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__NhanVien__A9D10534C9DDC864").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoVaTen).HasMaxLength(100);
            entity.Property(e => e.Idquyen).HasColumnName("IDQuyen");
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);

            entity.HasOne(d => d.IdquyenNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.Idquyen)
                .HasConstraintName("FK__NhanVien__IDQuye__71D1E811");
        });

        modelBuilder.Entity<QuyenHan>(entity =>
        {
            entity.HasKey(e => e.Idquyen).HasName("PK__QuyenHan__B3A2827EE4BA8725");

            entity.ToTable("QuyenHan");

            entity.HasIndex(e => e.TenQuyen, "UQ__QuyenHan__5637EE79465C358F").IsUnique();

            entity.Property(e => e.Idquyen).HasColumnName("IDQuyen");
            entity.Property(e => e.TenQuyen).HasMaxLength(100);
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PK__Sach__B235742D5C672594");

            entity.ToTable("Sach");

            entity.HasIndex(e => e.TenSach, "UQ__Sach__CA6B7B89B9B825DA").IsUnique();

            entity.Property(e => e.MaSach).HasMaxLength(10);
            entity.Property(e => e.AnhBia).HasMaxLength(255);
            entity.Property(e => e.MaNxb).HasColumnName("MaNXB");
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenSach).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasMaxLength(100);

            entity.HasOne(d => d.MaNgonNguNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaNgonNgu)
                .HasConstraintName("FK__Sach__MaNgonNgu__59063A47");

            entity.HasOne(d => d.MaNxbNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaNxb)
                .HasConstraintName("FK__Sach__MaNXB__5629CD9C");

            entity.HasOne(d => d.MaTacGiaNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaTacGia)
                .HasConstraintName("FK__Sach__MaTacGia__571DF1D5");

            entity.HasOne(d => d.MaTheLoaiNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaTheLoai)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Sach__MaTheLoai__5812160E");
        });

        modelBuilder.Entity<TacGium>(entity =>
        {
            entity.HasKey(e => e.MaTacGia).HasName("PK__TacGia__F24E6756F941A34D");

            entity.HasIndex(e => e.TenTacGia, "UQ__TacGia__2D926E306515F7E4").IsUnique();

            entity.Property(e => e.TenTacGia).HasMaxLength(100);
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.MaTheLoai).HasName("PK__TheLoai__D73FF34AA8CBEDC8");

            entity.ToTable("TheLoai");

            entity.HasIndex(e => e.TenTheLoai, "UQ__TheLoai__327F958F29052CA1").IsUnique();

            entity.Property(e => e.TenTheLoai).HasMaxLength(100);
        });

        modelBuilder.Entity<TheThuVien>(entity =>
        {
            entity.HasKey(e => e.MaThe).HasName("PK__TheThuVi__314EEAAFB3315294");

            entity.ToTable("TheThuVien");

            entity.Property(e => e.MaThe).HasMaxLength(10);
            entity.Property(e => e.NgayCapThe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoSachDangMuon).HasDefaultValue(0);
            entity.Property(e => e.SoSachDuocMuon).HasDefaultValue(0);

            entity.HasOne(d => d.MaDocGiaNavigation).WithMany(p => p.TheThuViens)
                .HasForeignKey(d => d.MaDocGia)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__TheThuVie__MaDoc__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
