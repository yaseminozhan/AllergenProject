using System;
using System.Collections.Generic;

namespace AlergenProject.UI.Entities;

public partial class UreticiveUrunler
{
    public int UreticiId { get; set; }

    public int UrunId { get; set; }

    public int? KategoriId { get; set; }

    public virtual Kategoriler? Kategori { get; set; }

    public virtual Ureticiler Uretici { get; set; } = null!;

    public virtual Urunler Urun { get; set; } = null!;
}
