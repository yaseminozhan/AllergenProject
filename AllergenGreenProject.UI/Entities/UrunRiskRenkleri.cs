using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlergenProject.UI.Entities;

public partial class UrunRiskRenkleri
{
    [Key]
    public int RenkId { get; set; }

    public string? RenkAdi { get; set; }

    public virtual ICollection<Urunler> Uruns { get; set; } = new List<Urunler>();
}
