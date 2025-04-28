using System.Diagnostics;
using AllergenGreenProject.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AlergenProject.UI.Controllers
{
    /*
     ana ekran yöneticisi olarak home controller ý kullanýyorum bu controllerda butonlarla diðer sayfalara yönlendirme 
     
    
     */
    public class HomeController : Controller
    {
        //bu controller sdece buton yönlendirmeleri için kullanýlacaðý için veritabaný eriþimine gerek yok o nedenle context eklemedim.

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

        // Barkod okuma ekranýna yönlendir
        public IActionResult BarkodOkuma()
        {
            return RedirectToAction("Tara", "Barkod");
        }

        // Arama ekranýna yönlendir
        public IActionResult Arama()
        {
            return RedirectToAction("Index", "Arama");
        }

        // Ürün ekleme/düzeltme ekranýna yönlendir
        public IActionResult UrunEkle()
        {
            return RedirectToAction("YeniEkle", "Urun");
        }

        // Favoriler/Geçmiþ ekranýna yönlendir
        public IActionResult Favoriler()
        {
            return RedirectToAction("Index", "Favori");
        }
        [Authorize(Roles = "Admin")] // Sadece admin görsün
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




        // Log testi için 

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
                Log.Error(ex, "TestLog içinde hata oluþtu.");
            }

            return Content("Log testi yapýldý. Hata oluþtuysa log dosyasýna yazýldý.");
        }

    }
}
