using System;
using System.Collections.Generic;

namespace eLibrary.Models;

public partial class TheThuVien
{
    public string MaThe { get; set; } = null!;

    public int? MaDocGia { get; set; }

    public DateTime? NgayCapThe { get; set; }

    public DateOnly? NgayHetHan { get; set; }

    public bool? TrangThai { get; set; }

    public int? SoSachDuocMuon { get; set; }

    public int? SoSachDangMuon { get; set; }

    public virtual DocGium? MaDocGiaNavigation { get; set; }

    public virtual ICollection<MuonTraSach> MuonTraSaches { get; set; } = new List<MuonTraSach>();
}
