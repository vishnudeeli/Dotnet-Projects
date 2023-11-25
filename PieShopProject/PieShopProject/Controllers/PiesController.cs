using Microsoft.AspNetCore.Mvc;
using PieShop.DataAccess.Repository.IRepository;
using PieShop.Models;
using System.Runtime.InteropServices;

namespace PieShopProject.Controllers
{
    public class PiesController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PiesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var allPies = _unitOfWork.Pie.GetAll();
            return View(allPies);
        }

        public IActionResult Create() 
        { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Pie pieObj)//, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                //if (file != null)
                //{
                //    string fileName = Guid.NewGuid().ToString();
                //    var uploads = Path.Combine(wwwRootPath, @"Images\Pies\");
                //    var extension = Path.GetExtension(file.FileName);
                //    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                //    {
                //        file.CopyTo(fileStreams);
                //    }
                //    pieObj.ImageUrl = @"Images\Pies\" + fileName + extension;
                //}

                _unitOfWork.Pie.Add(pieObj);
                _unitOfWork.Save();
                TempData["success"] = "Pies added successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(pieObj);

            
        }
        public IActionResult Details(int? pieId)
        {
            var pie = _unitOfWork.Pie.GetFirstOrDefault(c => c.PieId == pieId);
            return View(pie);
        }

    }
}
