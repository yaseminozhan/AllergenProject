using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlergenProject.UI.Entities;

public partial class KullaniciVeKaraListe
{
    [Key]
    public int KaraListeId { get; set; }

    public int? KullaniciId { get; set; }

    public int? UrunId { get; set; }

    public int? IceriklerId { get; set; }

    public virtual UrunVeIcerikler? Icerikler { get; set; }

    public virtual Kullanicilar? Kullanici { get; set; }

    public virtual Urunler? Urun { get; set; }
}
