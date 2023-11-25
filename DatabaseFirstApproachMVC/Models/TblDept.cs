using System;
using System.Collections.Generic;

namespace DatabaseFirstApproachMVC.Models;

public partial class TblDept
{
    public int DeptId { get; set; }

    public string? DeptName { get; set; }

    public virtual ICollection<TblEmployee> TblEmployees { get; } = new List<TblEmployee>();
}
