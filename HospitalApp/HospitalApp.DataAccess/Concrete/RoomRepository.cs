using Hospital.Models;
using HospitalApp.DataAccess.Abstract;
using HospitalApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalApp.DataAccess.Concrete
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateRoom(RoomViewModel roomViewModel)
        {
            var room = roomViewModel.ConvertViewModel(roomViewModel);
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var deleteRoom = _context.Rooms.Find(id);
            if (deleteRoom == null)
            {
                throw new KeyNotFoundException("Hospital not found.");
            }
            _context.Rooms.Remove(deleteRoom);
            _context.SaveChanges();
        }

        public List<RoomViewModel> GetAll()
        {
            var rooms = _context.Rooms.ToList();
            var roomViewModels = rooms.Select(h => new RoomViewModel(h)).ToList();
            return roomViewModels;
        }
        public List<RoomViewModel> GetAll(string includeProperties)
        {
            IQueryable<Room> query = _context.Rooms;

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            query = query.Include(r => r.Hospital);

            var rooms = query.ToList();
            var roomViewModels = rooms.Select(r => new RoomViewModel(r)).ToList();
            return roomViewModels;
        }


        public RoomViewModel GetRoomById(int RoomId)
        {
            var room = _context.Rooms.Find(RoomId);
            if (room == null)
            {
                return null;
            }
            return new RoomViewModel(room);
        }

        public void UpdateRoom(RoomViewModel roomViewModel)
        {
            var existingRoom = _context.Rooms.Find(roomViewModel.Id);
            if (existingRoom == null)
            {
                throw new KeyNotFoundException("Hospital not found.");
            }

            existingRoom.RoomNumber = roomViewModel.RoomNumber; 
            existingRoom.Status = roomViewModel.Status; 
            existingRoom.Type = roomViewModel.Type;
            existingRoom.HospitalId = roomViewModel.HospitalId;
          
            _context.Rooms.Update(existingRoom);
            _context.SaveChanges();
        }
    }
}
