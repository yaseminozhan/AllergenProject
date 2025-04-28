using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlergenProject.UI.Entities;

public partial class ProgramIzinleri
{
    [Key]
    public int IzinId { get; set; }

    public bool? Kamera { get; set; }

    public int? KullaniciId { get; set; }

    public virtual Kullanicilar? Kullanici { get; set; }
}
