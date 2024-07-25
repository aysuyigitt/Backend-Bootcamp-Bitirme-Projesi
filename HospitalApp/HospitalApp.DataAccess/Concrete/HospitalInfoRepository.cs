using Hospital.Models;
using HospitalApp.DataAccess.Abstract;
using HospitalApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalApp.DataAccess.Concrete
{
    public class HospitalInfoRepository : IHospitalInfoRepository
    {
        private readonly ApplicationDbContext _context;

        public HospitalInfoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateHospital(HospitalViewModel hospitalViewModel)
        {
            var hospital = hospitalViewModel.ConvertViewModel(hospitalViewModel);
            _context.HospitalInfos.Add(hospital);
            _context.SaveChanges();
        }

        public void DeleteHospital(int id)
        {
            var relatedRooms = _context.Rooms.Where(r => r.HospitalId == id).ToList();
            _context.Rooms.RemoveRange(relatedRooms);

            var deleteHospital = _context.HospitalInfos.Find(id);
            if (deleteHospital == null)
            {
                throw new KeyNotFoundException("Hospital not found.");
            }
            _context.HospitalInfos.Remove(deleteHospital);
            _context.SaveChanges();
        }

        public List<HospitalViewModel> GetAll()
        {
            var hospitals = _context.HospitalInfos.ToList();
            var hospitalViewModels = hospitals.Select(h => new HospitalViewModel(h)).ToList();
            return hospitalViewModels;
        }

        public HospitalViewModel GetHospitalById(int hospitalId)
        {
            var hospital = _context.HospitalInfos.Find(hospitalId);
            if (hospital == null)
            {
                return null;
            }
            return new HospitalViewModel(hospital);
        }

        public void UpdateHospital(HospitalViewModel hospitalViewModel)
        {
            var existingHospital = _context.HospitalInfos
                                           .SingleOrDefault(h => h.Id == hospitalViewModel.Id);

            if (existingHospital == null)
            {
                throw new KeyNotFoundException("Hospital not found.");
            }
            existingHospital.Name = hospitalViewModel.Name;
            existingHospital.Type = hospitalViewModel.Type;
            existingHospital.Country = hospitalViewModel.Country;
            existingHospital.City = hospitalViewModel.City;

            _context.HospitalInfos.Update(existingHospital);
            _context.SaveChanges();
        }
    }
}