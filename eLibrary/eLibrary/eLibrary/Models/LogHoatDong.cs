using System;
using System.Collections.Generic;

namespace eLibrary.Models;

public partial class LogHoatDong
{
    public int Id { get; set; }

    public DateTime? ThoiGian { get; set; }

    public string? MaNguoiDung { get; set; }

    public string? LoaiNguoiDung { get; set; }

    public string? HanhDong { get; set; }

    public string? BangLienQuan { get; set; }

    public string? KhoaChinh { get; set; }

    public string? GhiChu { get; set; }
}
