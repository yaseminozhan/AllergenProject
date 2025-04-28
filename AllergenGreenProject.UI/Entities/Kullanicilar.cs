using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AlergenProject.UI.Entities;

public partial class Kullanicilar : IdentityUser<int>
{
   
    public bool? IsPremium { get; set; }

    

    public virtual ICollection<KullaniciVeFavoriler> KullaniciVeFavorilers { get; set; } = new List<KullaniciVeFavoriler>();

    public virtual ICollection<KullaniciVeKaraListe> KullaniciVeKaraListes { get; set; } = new List<KullaniciVeKaraListe>();

    public virtual ICollection<ProgramIzinleri> ProgramIzinleris { get; set; } = new List<ProgramIzinleri>();

    public virtual ICollection<UrunTakipleri> UrunTakipleris { get; set; } = new List<UrunTakipleri>();

    public virtual ICollection<Urunler> Uruns { get; set; } = new List<Urunler>();
}
