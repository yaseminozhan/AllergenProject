using AlergenProject.UI.Entities;
using AllergenGreenProject.UI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AllergenGreenProject.UI.Context
{
    public class AllergenDbContext : IdentityDbContext<Kullanicilar, AppRole, int>
    {
        public AllergenDbContext()
        {
        }

        public AllergenDbContext(DbContextOptions<AllergenDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barkodlar> Barkodlars { get; set; }
        public virtual DbSet<Kategoriler> Kategorilers { get; set; }
        public virtual DbSet<KayitTipleri> KayitTipleris { get; set; }
        public virtual DbSet<KullaniciVeFavoriler> KullaniciVeFavorilers { get; set; }
        public virtual DbSet<KullaniciVeKaraListe> KullaniciVeKaraListes { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }
        public virtual DbSet<ProgramIzinleri> ProgramIzinleris { get; set; }
        public virtual DbSet<Riskler> Risklers { get; set; }
        public virtual DbSet<Ureticiler> Ureticilers { get; set; }
        public virtual DbSet<UreticiveUrunler> UreticiveUrunlers { get; set; }
        public virtual DbSet<UrunAramalar> UrunAramalars { get; set; }
        public virtual DbSet<UrunIcerikveRiskBilgileri> UrunIcerikveRiskBilgileris { get; set; }
        public virtual DbSet<UrunPaylasma> UrunPaylasmas { get; set; }
        public virtual DbSet<UrunRiskRenkleri> UrunRiskRenkleris { get; set; }
        public virtual DbSet<UrunTakipleri> UrunTakipleris { get; set; }
        public virtual DbSet<UrunVeIcerikler> UrunVeIceriklers { get; set; }
        public virtual DbSet<Urunler> Urunlers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Kullanici - Favori (Many-to-Many)
            modelBuilder.Entity<KullaniciVeFavoriler>()
                .HasKey(k => new { k.KullaniciId, k.UrunId });

            modelBuilder.Entity<KullaniciVeFavoriler>()
                .HasOne(k => k.Kullanici)
                .WithMany(k => k.KullaniciVeFavorilers)
                .HasForeignKey(k => k.KullaniciId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<KullaniciVeFavoriler>()
                .HasOne(k => k.Urun)
                .WithMany(u => u.KullaniciVeFavorilers)
                .HasForeignKey(k => k.UrunId)
                .OnDelete(DeleteBehavior.NoAction);

            // Kullanici - Kara Liste
            modelBuilder.Entity<KullaniciVeKaraListe>()
                .HasKey(k => k.KaraListeId);

            modelBuilder.Entity<KullaniciVeKaraListe>()
                .HasOne(k => k.Kullanici)
                .WithMany(k => k.KullaniciVeKaraListes)
                .HasForeignKey(k => k.KullaniciId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<KullaniciVeKaraListe>()
                .HasOne(k => k.Urun)
                .WithMany(u => u.KullaniciVeKaraListes)
                .HasForeignKey(k => k.UrunId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<KullaniciVeKaraListe>()
                .HasOne(k => k.Icerikler)
                .WithMany(i => i.KullaniciVeKaraListes)
                .HasForeignKey(k => k.IceriklerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Urun - Barkod (One-to-One & One-to-Many)
            modelBuilder.Entity<Urunler>()
                .HasOne(u => u.UrunBarkodNavigation)
                .WithMany(b => b.Urunlers)
                .HasForeignKey(u => u.UrunBarkod)
                .HasPrincipalKey(b => b.BarkodNo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Barkodlar>()
                .HasKey(b => b.BarkodNo);

            // Urun - Üretici
            modelBuilder.Entity<Urunler>()
                .HasOne(u => u.Uretici)
                .WithMany(u => u.Urunlers)
                .HasForeignKey(u => u.UreticiId)
                .OnDelete(DeleteBehavior.NoAction);

            // Urun - Kategori
            modelBuilder.Entity<Urunler>()
                .HasOne(u => u.Kategori)
                .WithMany(k => k.Urunlers)
                .HasForeignKey(u => u.KategoriId)
                .OnDelete(DeleteBehavior.NoAction);

            // Üretici ve Ürünler
            modelBuilder.Entity<UreticiveUrunler>()
                .HasKey(u => new { u.UreticiId, u.UrunId });

            modelBuilder.Entity<UreticiveUrunler>()
                .HasOne(u => u.Uretici)
                .WithMany(u => u.UreticiveUrunlers)
                .HasForeignKey(u => u.UreticiId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UreticiveUrunler>()
                .HasOne(u => u.Urun)
                .WithMany(u => u.UreticiveUrunlers)
                .HasForeignKey(u => u.UrunId)
                .OnDelete(DeleteBehavior.NoAction);

            // Urun ve İçerikler
            modelBuilder.Entity<UrunVeIcerikler>()
                .HasOne(u => u.Urun)
                .WithMany(u => u.UrunVeIceriklers)
                .HasForeignKey(u => u.UrunId)
                .OnDelete(DeleteBehavior.NoAction);

            // Risk ilişkisi (Many-to-Many custom)
            modelBuilder.Entity<UrunIcerikveRiskBilgileri>()
                .HasKey(r => new { r.IcerikId, r.RiskId });

            modelBuilder.Entity<UrunIcerikveRiskBilgileri>()
                .HasOne(r => r.Icerik)
                .WithMany(i => i.UrunIcerikveRiskBilgileris)
                .HasForeignKey(r => r.IcerikId)
                .OnDelete(DeleteBehavior.NoAction);

            // Urun Paylaşımı
            modelBuilder.Entity<UrunPaylasma>()
                .HasOne(p => p.Urun)
                .WithMany(u => u.UrunPaylasmas)
                .HasForeignKey(p => p.UrunId)
                .OnDelete(DeleteBehavior.NoAction);

            // Urun Takip
            modelBuilder.Entity<UrunTakipleri>()
                .HasOne(t => t.Kullanici)
                .WithMany(k => k.UrunTakipleris)
                .HasForeignKey(t => t.KullaniciId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UrunTakipleri>()
                .HasOne(t => t.Urun)
                .WithMany(u => u.UrunTakipleris)
                .HasForeignKey(t => t.UrunId)
                .OnDelete(DeleteBehavior.NoAction);

            // Program İzinleri
            modelBuilder.Entity<ProgramIzinleri>()
                .HasOne(p => p.Kullanici)
                .WithMany(k => k.ProgramIzinleris)
                .HasForeignKey(p => p.KullaniciId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new AppRole { Id = 2, Name = "PremiumUye", NormalizedName = "PREMIUMUYE" },
                new AppRole { Id = 3, Name = "NormalUye", NormalizedName = "NORMALUYE" }
            );
        }
    }
}
