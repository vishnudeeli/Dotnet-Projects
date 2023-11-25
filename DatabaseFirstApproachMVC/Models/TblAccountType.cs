using System;
using System.Collections.Generic;

namespace DatabaseFirstApproachMVC.Models;

public partial class TblAccountType
{
    public int AccountId { get; set; }

    public string AccountType { get; set; } = null!;

    public virtual ICollection<TblAccount> TblAccounts { get; } = new List<TblAccount>();
}
