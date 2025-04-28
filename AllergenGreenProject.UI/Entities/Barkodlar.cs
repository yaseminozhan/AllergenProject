using System;
using System.Collections.Generic;

namespace AlergenProject.UI.Entities;

public partial class Barkodlar
{
    public string BarkodNo { get; set; } = null!;

    public int UrunId { get; set; }

    public virtual Urunler Urun { get; set; } = null!;

    public virtual ICollection<Urunler> Urunlers { get; set; } = new List<Urunler>();
}
