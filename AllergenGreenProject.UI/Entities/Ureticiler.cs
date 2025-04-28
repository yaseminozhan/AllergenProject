using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlergenProject.UI.Entities;

public partial class Ureticiler
{
    [Key]
    public int UreticiId { get; set; }

    public string? UreticiAdi { get; set; }

    public virtual ICollection<UreticiveUrunler> UreticiveUrunlers { get; set; } = new List<UreticiveUrunler>();

    public virtual ICollection<Urunler> Urunlers { get; set; } = new List<Urunler>();
}
