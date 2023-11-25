using System;
using System.Collections.Generic;

namespace DatabaseFirstApproachMVC.Models;

public partial class TblCountry
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Capital { get; set; }

    public int? Population { get; set; }

    public decimal? Economy { get; set; }

    public string? Currency { get; set; }
}
