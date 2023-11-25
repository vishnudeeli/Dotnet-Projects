using BookProject.DataAccess.Repository.IRepository;
using BookProject.Models.Models;
using BookProject.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace WebAppMVCDotNet6.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BooksController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
          //  return _unitOfWork.Book.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult InsertUpt(int? id)
        {
            //Book book-new Book();
            // Book book = new(); //c# 10.0
            BookViewModel bookVM = new()
            {
                Book = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
        };
            //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
            //    u=>new SelectListItem
            //    { 
            //    Text=u.Name,
            //    Value=u.Id.ToString()
            //});
            if (id == null || id == 0)
            {
                //create Product
               // ViewBag.CategoryList = CategoryList;
               // ViewData["CategoryList1"] = CategoryList;

                return View(bookVM);
            }
            else
            {
                //Update Product
            }
            return View();
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
      public IActionResult InsertUpt(BookViewModel obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath; 
                if (file != null) { 
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\Books\");
                    var extension = Path.GetExtension(file.FileName); 
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName), FileMode.Create)) 
                    { 
                        file.CopyTo(fileStreams); 
                    } 
                    obj.Book.ImageUrl = @"Images\Books\" + fileName + extension;
                }

                _unitOfWork.Book.Add(obj.Book);
                _unitOfWork.Save();
                TempData["success"] = "Book added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region BookAPICrudEndPoints
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookLIst = _unitOfWork.Book.GetAll(includeProperties:"Category");
            return Json(new {data=bookLIst});
        }


        #endregion
    }
}
