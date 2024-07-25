using Hospital.Models;
using HospitalApp.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentsController : Controller
    {
        private IDepartmentRepository _department;

        public DepartmentsController(IDepartmentRepository department)
        {
            _department = department;
        }
        public IActionResult Index()
        {
            return View(_department.GetAll(IncludeProperties: "Hospital"));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var departmentModel = _department.GetDepartmentById(id);
            return View(departmentModel);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentViewModel dp)
        {
            _department.UpdateDepartment(dp);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentViewModel dp)
        {
            _department.CreateDepartment(dp);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _department.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
    }
}


