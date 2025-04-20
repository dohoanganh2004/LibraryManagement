using System;
using System.Collections.Generic;

namespace eLibrary.Models;

public partial class Sach
{
    public string MaSach { get; set; } = null!;

    public int? MaNxb { get; set; }

    public string TenSach { get; set; } = null!;

    public string? MoTa { get; set; }

    public int? MaTacGia { get; set; }

    public int? MaTheLoai { get; set; }

    public DateOnly? NamXuatBan { get; set; }

    public int? MaNgonNgu { get; set; }

    public string? AnhBia { get; set; }

    public string? TrangThai { get; set; }

    public int? Gia { get; set; }

    public int? SoLuong { get; set; }

    public virtual NgonNgu? MaNgonNguNavigation { get; set; }

    public virtual NhaXuatBan? MaNxbNavigation { get; set; }

    public virtual TacGium? MaTacGiaNavigation { get; set; }

    public virtual TheLoai? MaTheLoaiNavigation { get; set; }

    public virtual ICollection<MuonTraSachChiTiet> MuonTraSachChiTiets { get; set; } = new List<MuonTraSachChiTiet>();
}
