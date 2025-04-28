using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlergenProject.UI.Entities;

public partial class Urunler
{
    [Key]
    public int UrunId { get; set; }

        public string UrunAdi { get; set; }

        public string UrunIcerigi { get; set; }

        public int KategoriId { get; set; }

        public int UreticiId { get; set; }

        public string UrunBarkod { get; set; } 

        public string? UrunRiskRenkleri { get; set; }

        public byte[]? UrunOnYuzu { get; set; }

        public byte[]? UrunArkaYuzu { get; set; }

        public virtual Kategoriler? Kategori { get; set; }

        public virtual Ureticiler? Uretici { get; set; }
    


    public virtual ICollection<Barkodlar> Barkodlars { get; set; } = new List<Barkodlar>();

   

    public virtual ICollection<KullaniciVeFavoriler> KullaniciVeFavorilers { get; set; } = new List<KullaniciVeFavoriler>();

    public virtual ICollection<KullaniciVeKaraListe> KullaniciVeKaraListes { get; set; } = new List<KullaniciVeKaraListe>();

   

    public virtual ICollection<UreticiveUrunler> UreticiveUrunlers { get; set; } = new List<UreticiveUrunler>();

    public virtual Barkodlar? UrunBarkodNavigation { get; set; }

    public virtual ICollection<UrunPaylasma> UrunPaylasmas { get; set; } = new List<UrunPaylasma>();

    public virtual ICollection<UrunTakipleri> UrunTakipleris { get; set; } = new List<UrunTakipleri>();

    public virtual ICollection<UrunVeIcerikler> UrunVeIceriklers { get; set; } = new List<UrunVeIcerikler>();

    public virtual ICollection<Kullanicilar> Kullanicis { get; set; } = new List<Kullanicilar>();

    public virtual ICollection<UrunRiskRenkleri> Renks { get; set; } = new List<UrunRiskRenkleri>();

    public virtual ICollection<Riskler> Risks { get; set; } = new List<Riskler>();


}
