using System;
using System.Collections.Generic;

namespace eLibrary.Models;

public partial class TacGium
{
    public int MaTacGia { get; set; }

    public string TenTacGia { get; set; } = null!;

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
