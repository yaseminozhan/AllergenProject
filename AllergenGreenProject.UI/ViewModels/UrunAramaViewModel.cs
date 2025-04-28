using AlergenProject.UI.Entities;
using System.Collections.Generic;

namespace AlergenProject.UI.ViewModels
{
    public class UrunAramaViewModel
    {
        public List<Kategoriler> Kategoriler { get; set; }
        public List<Ureticiler> Ureticiler { get; set; }

        public int? SeciliKategoriId { get; set; }
        public int? SeciliUreticiId { get; set; }

        public List<Urunler> Urunler { get; set; } = new List<Urunler>();
    }
}
