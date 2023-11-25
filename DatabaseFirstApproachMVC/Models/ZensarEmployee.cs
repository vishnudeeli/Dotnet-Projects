using System;
using System.Collections.Generic;

namespace DatabaseFirstApproachMVC.Models;

public partial class ZensarEmployee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? PhoneNumber { get; set; }

    public int? SkillId { get; set; }

    public int? YearsExperience { get; set; }

    public virtual TblSkill? Skill { get; set; }
}
