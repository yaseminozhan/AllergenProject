using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlergenProject.UI.Entities;

public partial class UrunTakipleri
{
    [Key]
    public int TakipId { get; set; }

    public int? KullaniciId { get; set; }

    public int? UrunId { get; set; }

    public bool? Revise { get; set; }

    public virtual Kullanicilar? Kullanici { get; set; }

    public virtual Urunler? Urun { get; set; }
}
