using Microsoft.AspNetCore.Mvc;
using BookProject.DataAccess.Data;
using BookProject.Models.Models;
using BookProject.DataAccess.Repository.IRepository;

namespace WebAppMvcDotNet6.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()

        {
            var allCategories = _unitOfWork.Category.GetAll();



            //TempData["Fname"] = "Vranda";
            //TempData["Lname"] = "Daga";
            //ViewBag.MyName = "Manu";
            //ViewData["Data"] = 100;
            return View(allCategories);
        }
        public IActionResult Details(int? id)
        {
            var category = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            return View(category);
        }
        public IActionResult Create()
        {



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category catObj)
        {




            if (catObj.Name == catObj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom Error", "DisplayOrder cannot match the name");
            }




            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(catObj);
                _unitOfWork.Save();




                return RedirectToAction(nameof(Index));
                return View(catObj);
            }
            else
            {
                return View(catObj);
            }
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _categoryRepository.;
            var categoryFirstOrDefault = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            //var categorySingleOrDefault = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFirstOrDefault == null)
            {
                return NotFound();
            }
            return View(categoryFirstOrDefault);





        }
        //Edit-Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult Edit(Category catObj)
        {




            //if (catObj.Name == catObj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Custom Error", "DisplayOrder cannot match the name");
            //}




            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(catObj);
                _unitOfWork.Save();
                TempData["Success"] = "Category updated succesfully";



                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(catObj);
            }
        }
        //Delete - Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            //var categoryFirstOrDefault=_db.Categories.FirstOrDefault(c => c.Id == id);
            //var categorySingleOrDefault = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);





        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Category deleted succesfully";
            return RedirectToAction(nameof(Index));
        }



    }
}
