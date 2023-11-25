using BookProject.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Web.Mvc;

namespace BookProject.Models.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        [ValidateNever]
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> CategoryList { get; set; }
    }
}
