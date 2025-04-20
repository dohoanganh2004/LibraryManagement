using System;
using System.Collections.Generic;

namespace eLibrary.Models;

public partial class MuonTraSach
{
    public int MaMuonSach { get; set; }

    public string? MaThe { get; set; }

    public string? GhiChu { get; set; }

    public virtual TheThuVien? MaTheNavigation { get; set; }

    public virtual ICollection<MuonTraSachChiTiet> MuonTraSachChiTiets { get; set; } = new List<MuonTraSachChiTiet>();
}
