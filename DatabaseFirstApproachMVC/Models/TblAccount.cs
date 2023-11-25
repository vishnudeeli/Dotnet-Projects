using System;
using System.Collections.Generic;

namespace DatabaseFirstApproachMVC.Models;

public partial class TblAccount
{
    public string? CustomerId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public int? AccountId { get; set; }

    public DateTime AccOpenDate { get; set; }

    public double? AccBalance { get; set; }

    public virtual TblAccountType? Account { get; set; }

    public virtual TblCustomer? Customer { get; set; }
}
