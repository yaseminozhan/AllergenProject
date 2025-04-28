using AllergenGreenProject.UI.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlergenProject.UI.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin erişebilir
    public class BarkodController : Controller
    {
        private readonly AllergenDbContext _context;

        public BarkodController(AllergenDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Tara()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Tara(string barkodNo)
        {
            if (string.IsNullOrWhiteSpace(barkodNo))
            {
                TempData["Mesaj"] = "Lütfen bir barkod giriniz.";
                return View();
            }

            var urun = _context.Urunlers
                .Include(u => u.Kategori)
                .Include(u => u.Uretici)
                .FirstOrDefault(u => u.UrunBarkod == barkodNo);

            if (urun != null)
            {
                return RedirectToAction("Detay", "Urun", new { id = urun.UrunId });
            }

            // Eğer ürün bulunamazsa
            TempData["Mesaj"] = "❌ Barkoda ait ürün bulunamadı. Yeni ürün eklemek ister misiniz?";
            TempData["BarkodNo"] = barkodNo; // Barkod bilgisini taşırız
            return View(); // Tara sayfasında mesaj ve "Yeni Ürün Ekle" butonu çıkar
        }
    }
}
