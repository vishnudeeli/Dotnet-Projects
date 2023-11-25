using System.ComponentModel.DataAnnotations;
namespace CoreWebAppDatabaseApproach.Models
{
    public class tblSkill
    {
        public int SkillID { get; set; }

        [Display(Name = "Type of Skill")]
        public string Title { get; set; }
    }
}
