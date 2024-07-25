using Hospital.Models;
using HospitalApp.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomsController : Controller
    {
        private IRoomRepository _room;

        public RoomsController(IRoomRepository room)
        {
            _room = room;
        }
        public IActionResult Index()
        {
            return View(_room.GetAll(IncludeProperties:"Hospital"));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var roomModel = _room.GetRoomById(id);
            return View(roomModel); 
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel rm)
        {
            _room.UpdateRoom(rm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoomViewModel rm)
        {
            _room.CreateRoom(rm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _room.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
    }

