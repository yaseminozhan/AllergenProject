using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlergenProject.UI.Entities;

public partial class UrunPaylasma
{
    [Key]
    public int PaylasmaId { get; set; }

    public string? PaylasmaTipi { get; set; }

    public int? UrunId { get; set; }

    public virtual Urunler? Urun { get; set; }
}
