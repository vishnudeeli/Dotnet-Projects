using System;
using System.Collections.Generic;

namespace DbFirstApproachMVC.Models;

public partial class TblCountry
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string Captital { get; set; } = null!;

    public double Economy { get; set; }

    public string Currency { get; set; } = null!;
}
