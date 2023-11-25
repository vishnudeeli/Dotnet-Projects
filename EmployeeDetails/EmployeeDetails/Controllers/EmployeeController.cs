using EmployeeDetails.Data;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeDetails.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _db;

        public EmployeeController(EmployeeDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {



            var employees = _db.Employees.ToList();

            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Employee obj)
        {
            
           
            var mob = obj.MobileNo;
            var total = (from x in _db.Employees where x.MobileNo == mob select x).ToList();
            if (ModelState.IsValid)
            {
                if (total.Count > 0)
                {
                    TempData["duplicate"] = "Mobile number already Present";
                    return RedirectToAction(nameof(Create));
                    
                }

                TempData["Success"] = "Employee added successfully";

                _db.Employees.Add(obj);
                _db.SaveChanges();
                

            }
            return RedirectToAction(nameof(Index));

        }
    }
}
