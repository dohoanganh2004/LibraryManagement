using System;
using System.Collections.Generic;

namespace eLibrary.Models;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string HoVaTen { get; set; } = null!;

    public string? Email { get; set; }

    public string? SoDienThoai { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? Avartar { get; set; }

    public string? MatKhau { get; set; }

    public int? Idquyen { get; set; }

    public virtual QuyenHan? IdquyenNavigation { get; set; }
}
