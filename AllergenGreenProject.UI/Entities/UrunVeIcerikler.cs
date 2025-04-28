using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlergenProject.UI.Entities;

public partial class UrunVeIcerikler
{
    [Key]
    public int IcerikId { get; set; }

    public int? UrunId { get; set; }

    public int? KategoriId { get; set; }

    public string? KullanimKosullari { get; set; }

    public virtual Kategoriler? Kategori { get; set; }

    public virtual ICollection<KullaniciVeKaraListe> KullaniciVeKaraListes { get; set; } = new List<KullaniciVeKaraListe>();

    public virtual Urunler? Urun { get; set; }

    public virtual ICollection<UrunIcerikveRiskBilgileri> UrunIcerikveRiskBilgileris { get; set; } = new List<UrunIcerikveRiskBilgileri>();
}
