using Hospital.Models;
using HospitalApp.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentsController : Controller
    {
        private IAppointmentRepository _appointment;
        private IApplicationUserRepository _userRepository;
        

        public AppointmentsController(IAppointmentRepository appointment, IApplicationUserRepository userRepository)
        {
            _appointment = appointment;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View(_appointment.GetAll("Hospital,Doctors,Patients"));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //ViewBag.Hospitals = new SelectList(_userRepository.GetAllHospitals(), "Id", "Name");
            //ViewBag.Doctors = new SelectList(_userRepository.GetAllDoctor(), "Id", "Name");
            //ViewBag.Patients = new SelectList(_userRepository.GetAllPatient(), "Id", "Name");

            var appointmentModel = _appointment.GetAppoinmentGetById(id);
            return View(appointmentModel);
            
        }
        [HttpPost]
        public IActionResult Edit(AppointmentViewModel ap)
        {
            _appointment.UpdateAppointment(ap);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Hospitals = new SelectList(_userRepository.GetAllHospitals(), "Id", "Name");
           // ViewBag.Doctors = new SelectList(_userRepository.GetAllDoctor(), "Id", "Name");
            //ViewBag.Patients = new SelectList(_userRepository.GetAllPatient(), "Id", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult Create(AppointmentViewModel ap)
        {
           _appointment.CreateAppointment(ap);
            return RedirectToAction("Index");
        }
    }
}
