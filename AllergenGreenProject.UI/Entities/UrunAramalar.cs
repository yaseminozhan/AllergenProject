using System;
using System.Collections.Generic;

namespace AlergenProject.UI.Entities;

public partial class UrunAramalar
{
    public int Id{ get; set; }
    public string? BarkodNo { get; set; }

    public string? UrunAdi { get; set; }

    public int? KategoriId { get; set; }

    public virtual Barkodlar? BarkodNoNavigation { get; set; }

    public virtual Kategoriler? Kategori { get; set; }
}
