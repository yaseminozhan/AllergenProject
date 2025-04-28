using AlergenProject.UI.Entities;
using AlergenProject.UI.ViewModels;
using AllergenGreenProject.UI.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AlergenProject.UI.Controllers
{
   
    public class UrunController : Controller
    {
        private readonly AllergenDbContext _context;

        public UrunController(AllergenDbContext context)
        {
            _context = context;
        }

        // Eşleşen ürün detayını göstermek için detay actionu oluşturduk ve ürün id'sini parametre olarak alıyoruz.id si ile ürün bulma işlemi yapacağımız için
        public IActionResult Detay(int id)
        {
            var urun = _context.Urunlers
                        .Include(u => u.Kategori)
                        .Include(u => u.Uretici)
                        .FirstOrDefault(u => u.UrunId == id);

            if (urun == null)
            {
                return NotFound("Ürün bulunamadı.");
            }
            Console.WriteLine("TEMP DATA: " + TempData["Mesaj"]);

            return View(urun);
        }

        // barkodlu ürün yoksa yeni barkodlu ürün ekleme ekranı gelir.
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult YeniEkle(string barkod)
        {
            ViewBag.Kategoriler = _context.Kategorilers.ToList();
            ViewBag.Ureticiler = _context.Ureticilers.ToList();

            var yeniUrun = new Urunler
            {
                UrunBarkod = barkod // Barkodu varsayılan veriyoruz
            };

            return View(yeniUrun);
        }


        //formdan gelen verileri alarak yeni ürünü veritabanına ekleme işlemi yapacağız.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> YeniEkle(Urunler model, IFormFile UrunOnYuzuFile, IFormFile UrunArkaYuzuFile)
        {
            ViewBag.Kategoriler = _context.Kategorilers.ToList();
            ViewBag.Ureticiler = _context.Ureticilers.ToList();

            if (string.IsNullOrWhiteSpace(model.UrunBarkod))
            {
                ModelState.AddModelError("UrunBarkod", "Barkod boş olamaz.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                if (UrunOnYuzuFile != null)
                {
                    using var ms = new MemoryStream();
                    await UrunOnYuzuFile.CopyToAsync(ms);
                    model.UrunOnYuzu = ms.ToArray();
                }

                if (UrunArkaYuzuFile != null)
                {
                    using var ms = new MemoryStream();
                    await UrunArkaYuzuFile.CopyToAsync(ms);
                    model.UrunArkaYuzu = ms.ToArray();
                }

                try
                {
                    _context.Urunlers.Add(model);
                    await _context.SaveChangesAsync();

                    TempData["Mesaj"] = "✅ Ürün başarıyla eklendi!";
                    return RedirectToAction("Listele");
                }
                catch (DbUpdateException ex)
                {
                    Log.Error(ex, "Veritabanı ekleme hatası oluştu: {Message}", ex.Message);

                    if (ex.InnerException != null && ex.InnerException.Message.Contains("UQ_Urunlers_UrunBarkod"))
                    {
                        // Eğer hata UrunBarkod UNIQUE ihlaliyse özel mesaj verelim
                        ModelState.AddModelError("", "❌ Bu ürün barkodu zaten kayıtlı. Lütfen farklı bir barkod numarası giriniz.");
                    }
                    else
                    {
                        // Diğer hatalar için yine genel hata mesajı verelim
                        ModelState.AddModelError("", "❌ Bir veritabanı hatası oluştu. Lütfen tekrar deneyin.");
                    }
                }

            }

            return View(model);
        }


        //güncelleme de ekleyelim

        [Authorize(Roles = "Admin")] //yalnızca admin erişimi
        [HttpGet]
        public IActionResult GuncelleBaslat()
        {
            var urunler = _context.Urunlers
                .Include(u => u.Kategori)
                .Include(u => u.Uretici)
                .ToList();

            return View("GuncelleUrunSec", urunler); 
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var urun = _context.Urunlers.FirstOrDefault(u => u.UrunId == id);

            if (urun == null)
                return NotFound("Bu ID ile eşleşen ürün bulunamadı.");

            ViewBag.Kategoriler = _context.Kategorilers.ToList();
            ViewBag.Ureticiler = _context.Ureticilers.ToList();

            return View(urun); 
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Guncelle(Urunler model, IFormFile UrunOnYuzuFile, IFormFile UrunArkaYuzuFile)
        {
            var urun = _context.Urunlers.FirstOrDefault(u => u.UrunId == model.UrunId);
            if (urun == null)
                return NotFound("Ürün bulunamadı!");

            urun.UrunAdi = model.UrunAdi;
            urun.UrunIcerigi = model.UrunIcerigi;
            urun.KategoriId = model.KategoriId;
            urun.UreticiId = model.UreticiId;

            if (UrunOnYuzuFile != null)
            {
                using var ms = new MemoryStream();
                await UrunOnYuzuFile.CopyToAsync(ms);
                urun.UrunOnYuzu = ms.ToArray();
            }

            if (UrunArkaYuzuFile != null)
            {
                using var ms = new MemoryStream();
                await UrunArkaYuzuFile.CopyToAsync(ms);
                urun.UrunArkaYuzu = ms.ToArray();
            }

            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "✅ Ürün başarıyla güncellendi!";
            return RedirectToAction("Listele");
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var urun = await _context.Urunlers.FindAsync(id);
            if (urun == null)
            {
                return NotFound("Silinecek ürün bulunamadı.");
            }

            _context.Urunlers.Remove(urun);
            await _context.SaveChangesAsync();

            TempData["Mesaj"] = "✅ Ürün başarıyla silindi!";
            return RedirectToAction("Listele");
        }



        //ürünleri görelim
        public IActionResult Listele()
        {
            var urunler = _context.Urunlers
                .Include(u => u.Kategori)
                .Include(u => u.Uretici)
                .ToList();

            return View(urunler);
        }

        // Kategoriye göre ürünleri listele
        [HttpGet]
        public IActionResult UrunleriGetirByKategori(int kategoriId)
        {
            var urunler = _context.Urunlers
                .Where(u => u.KategoriId == kategoriId)
                .ToList();

            return View("KategoriyeGoreUrunler", urunler);
        }

        // Barkoda göre ürün detay
      
        [HttpGet]
        public IActionResult UrunDetayByBarkod(string barkod)
        {
            var urun = _context.Urunlers
                .Include(u => u.Kategori)
                .Include(u => u.Uretici)
                .FirstOrDefault(u => u.UrunBarkod == barkod);

            if (urun == null)
            {
                return View("UrunDetayYok"); 
            }

            return View("UrunDetay", urun);
        }
        [HttpGet]
        public IActionResult Arama()
        {
            var model = new UrunAramaViewModel
            {
                Kategoriler = _context.Kategorilers.ToList(),
                Ureticiler = _context.Ureticilers.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Arama(UrunAramaViewModel model)
        {
            var query = _context.Urunlers
                .Include(u => u.Kategori)
                .Include(u => u.Uretici)
                .AsQueryable();

            if (model.SeciliKategoriId.HasValue)
            {
                query = query.Where(u => u.KategoriId == model.SeciliKategoriId.Value);
            }

            if (model.SeciliUreticiId.HasValue)
            {
                query = query.Where(u => u.UreticiId == model.SeciliUreticiId.Value);
            }

            model.Kategoriler = _context.Kategorilers.ToList();
            model.Ureticiler = _context.Ureticilers.ToList();
            model.Urunler = query.ToList();

            return View(model);
        }


    }
}

