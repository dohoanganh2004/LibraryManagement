using System;
using System.Collections.Generic;

namespace eLibrary.Models;

public partial class DocGium
{
    public int MaDocGia { get; set; }

    public string TenDocGia { get; set; } = null!;

    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string Email { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public string? MatKhau { get; set; }

    public string? Avartar { get; set; }

    public virtual ICollection<TheThuVien> TheThuViens { get; set; } = new List<TheThuVien>();
}
