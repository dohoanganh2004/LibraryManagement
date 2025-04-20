using System;
using System.Collections.Generic;

namespace eLibrary.Models;

public partial class MuonTraSachChiTiet
{
    public int MaMuonSach { get; set; }

    public string MaSach { get; set; } = null!;

    public DateOnly? NgayMuon { get; set; }

    public DateOnly? NgayHenTra { get; set; }

    public DateOnly? NgayTra { get; set; }

    public string? TrangThai { get; set; }

    public int? SoLuong { get; set; }

    public virtual MuonTraSach MaMuonSachNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
