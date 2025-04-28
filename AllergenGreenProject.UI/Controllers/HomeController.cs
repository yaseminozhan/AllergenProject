using System.Diagnostics;
using AllergenGreenProject.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AlergenProject.UI.Controllers
{
    /*
     ana ekran y�neticisi olarak home controller � kullan�yorum bu controllerda butonlarla di�er sayfalara y�nlendirme 
     
    
     */
    public class HomeController : Controller
    {
        //bu controller sdece buton y�nlendirmeleri i�in kullan�laca�� i�in veritaban� eri�imine gerek yok o nedenle context eklemedim.

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //anasayfa
        public IActionResult Index()
        {
            return View();
        }

        // Barkod okuma ekran�na y�nlendir
        public IActionResult BarkodOkuma()
        {
            return RedirectToAction("Tara", "Barkod");
        }

        // Arama ekran�na y�nlendir
        public IActionResult Arama()
        {
            return RedirectToAction("Index", "Arama");
        }

        // �r�n ekleme/d�zeltme ekran�na y�nlendir
        public IActionResult UrunEkle()
        {
            return RedirectToAction("YeniEkle", "Urun");
        }

        // Favoriler/Ge�mi� ekran�na y�nlendir
        public IActionResult Favoriler()
        {
            return RedirectToAction("Index", "Favori");
        }
        [Authorize(Roles = "Admin")] // Sadece admin g�rs�n
        [HttpGet]
        public IActionResult UrunIslemler()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        // Log testi i�in 

        public IActionResult TestLog()
        {
            try
            {
                int a = 5;
                int b = 0;
                int sonuc = a / b;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "TestLog i�inde hata olu�tu.");
            }

            return Content("Log testi yap�ld�. Hata olu�tuysa log dosyas�na yaz�ld�.");
        }

    }
}
