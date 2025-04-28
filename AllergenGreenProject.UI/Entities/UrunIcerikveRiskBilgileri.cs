using System;
using System.Collections.Generic;

namespace AlergenProject.UI.Entities;

public partial class UrunIcerikveRiskBilgileri
{
    public int IcerikId { get; set; }

    public int RiskId { get; set; }

    public virtual UrunVeIcerikler Icerik { get; set; } = null!;
}
