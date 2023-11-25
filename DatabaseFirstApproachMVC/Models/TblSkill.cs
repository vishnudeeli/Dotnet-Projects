using System;
using System.Collections.Generic;

namespace DatabaseFirstApproachMVC.Models;

public partial class TblSkill
{
    public int SkillId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<ZensarEmployee> ZensarEmployees { get; } = new List<ZensarEmployee>();
}
