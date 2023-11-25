using System.ComponentModel.DataAnnotations;
namespace CoreWebAppDatabaseApproach.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public string PhoneNumber { get; set; }

        public string Skill { get; set; }

        public int YearsExperience { get; set; }

    }
}
