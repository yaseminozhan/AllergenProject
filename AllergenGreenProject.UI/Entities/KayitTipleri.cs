using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlergenProject.UI.Entities;

public partial class KayitTipleri
{
    [Key]
    public int KayitTipiId { get; set; }

    public string? KayitAdi { get; set; }

    public virtual ICollection<Kullanicilar> Kullanicilars { get; set; } = new List<Kullanicilar>();
}
