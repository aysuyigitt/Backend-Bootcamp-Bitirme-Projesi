using Hospital.Models;
using HospitalApp.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class HospitalsController : Controller
    {
        private IHospitalInfoRepository _hospitalInfo;

        public HospitalsController(IHospitalInfoRepository hospitalInfo)
        {
            _hospitalInfo = hospitalInfo;
        }

        public IActionResult Index()
        {
            return View(_hospitalInfo.GetAll());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hospitalModel = _hospitalInfo.GetHospitalById(id);
            return View(hospitalModel);
        }
        [HttpPost]
        public IActionResult Edit(HospitalViewModel hp)
        {
            _hospitalInfo.UpdateHospital(hp);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HospitalViewModel hp)
        {
            _hospitalInfo.CreateHospital(hp);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _hospitalInfo.DeleteHospital(id);
            return RedirectToAction("Index");
        }
    }
}

