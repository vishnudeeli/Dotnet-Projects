using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BookProject.Models.Models
{
    public class Category
    {
        //[Key]
        public int Id { get; set; }
        [StringLength(20)]
        [Required]
        
     // [RegularExpression("^[A-za-z]+[\\s]{1}[A-za-z]+", ErrorMessage = "Only Enter the Characters")]

        [Display(Name="Category Name")]
        public string Name { get; set; }
     
        [Range(1, 100, ErrorMessage = "Display order range is between  1 to 100")]


        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
