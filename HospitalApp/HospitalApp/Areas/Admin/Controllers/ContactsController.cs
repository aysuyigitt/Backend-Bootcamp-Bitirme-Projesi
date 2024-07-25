using Hospital.Models;
using HospitalApp.DataAccess.Abstract;
using HospitalApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactsController : Controller
    {
        private IContactRepository _contact;
        private IHospitalInfoRepository _hospitalInfo;

        public ContactsController(IContactRepository contact, IHospitalInfoRepository hospitalInfo)
        {
            _contact = contact;
            _hospitalInfo = hospitalInfo;
        }

        public IActionResult Index()
        {
            return View(_contact.GetAll(IncludeProperties: "Hospital"));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.hospital = new SelectList(_hospitalInfo.GetAll(), "Id", "Name");

            var contactModel = _contact.GetContactGetById(id);
            return View(contactModel);
        }
        [HttpPost]
        public IActionResult Edit(ContactViewModel cn)
        {
            _contact.UpdateContact(cn);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.hospital = new SelectList(_hospitalInfo.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactViewModel cn)
        {
            _contact.CreateContact(cn);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _contact.DeleteContact(id); 
            return RedirectToAction("Index");
        }
    }
    }

    

