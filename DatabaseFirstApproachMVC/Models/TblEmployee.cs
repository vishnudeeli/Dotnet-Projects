using System;
using System.Collections.Generic;

namespace DatabaseFirstApproachMVC.Models;

public partial class TblEmployee
{
    public int EmpNo { get; set; }

    public string? EmpName { get; set; }

    public double? EmpSal { get; set; }

    public int? DeptId { get; set; }

    public virtual TblDept? Dept { get; set; }
}
