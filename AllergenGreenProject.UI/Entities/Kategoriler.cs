using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlergenProject.UI.Entities;

public partial class Kategoriler
{
    [Key]
    public int KategoriId { get; set; }

    public string? KategoriAdi { get; set; }

    public virtual ICollection<KullaniciVeFavoriler> KullaniciVeFavorilers { get; set; } = new List<KullaniciVeFavoriler>();

    public virtual ICollection<UreticiveUrunler> UreticiveUrunlers { get; set; } = new List<UreticiveUrunler>();

    public virtual ICollection<UrunVeIcerikler> UrunVeIceriklers { get; set; } = new List<UrunVeIcerikler>();

    public virtual ICollection<Urunler> Urunlers { get; set; } = new List<Urunler>();
}
