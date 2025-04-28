using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlergenProject.UI.Entities;

public partial class Riskler
{
    [Key]
    public int RiskId { get; set; }

    public string? RiskAdi { get; set; }

    public virtual ICollection<Urunler> Uruns { get; set; } = new List<Urunler>();
}
