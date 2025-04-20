using System;
using System.Collections.Generic;

namespace eLibrary.Models;

public partial class QuyenHan
{
    public int Idquyen { get; set; }

    public string TenQuyen { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
