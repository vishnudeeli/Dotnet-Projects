using System;
using System.Collections.Generic;

namespace DatabaseFirstApproachMVC.Models;

public partial class TblCustomer
{
    public string CustomerId { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string? City { get; set; }

    public virtual ICollection<TblAccount> TblAccounts { get; } = new List<TblAccount>();
}
