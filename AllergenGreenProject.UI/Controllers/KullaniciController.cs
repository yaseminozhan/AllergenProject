using Microsoft.AspNetCore.Mvc;

namespace AllergenGreenProject.UI.Controllers
{
    public class KullaniciController : Controller
    {
        [HttpGet]
        public IActionResult Misafir()
        {
            return View();
        }

        public IActionResult ErisimYok()
        {
            return View();
        }
    }
}
