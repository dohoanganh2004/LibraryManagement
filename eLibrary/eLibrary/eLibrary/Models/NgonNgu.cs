using System;
using System.Collections.Generic;

namespace eLibrary.Models;

public partial class NgonNgu
{
    public int MaNgonNgu { get; set; }

    public string TenNgonNgu { get; set; } = null!;

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
