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
        public class AppointmentRepository : IAppointmentRepository
        {
            private readonly ApplicationDbContext _context;

            public AppointmentRepository(ApplicationDbContext context)
            {
                _context = context;
            }
            public void CreateAppointment(AppointmentViewModel appointmentViewModel)
        {
            var appointment = appointmentViewModel.ConvertViewModel(appointmentViewModel);
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void DeleteAppointment(int id)
        {
            var deleteAppointmnet = _context.Appointments.Find(id);
            if (deleteAppointmnet == null)
            {
                throw new KeyNotFoundException("Appoinment not found.");
            }
            _context.Appointments.Remove(deleteAppointmnet);
            _context.SaveChanges();
        }
    
        public List<AppointmentViewModel> GetAll()
        {
            var appointments = _context.Appointments.ToList();
            var appointmentViewModels = appointments.Select(h => new AppointmentViewModel(h)).ToList();
            return appointmentViewModels;
        }

        public List<AppointmentViewModel> GetAll(string includeProperties)
        {
            IQueryable<Appointment> query = _context.Appointments;

            if (!string.IsNullOrEmpty(includeProperties))
            {
                var validIncludes = new List<string> { "Doctor", "Patient", "Hospital" };

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (validIncludes.Contains(includeProperty.Trim()))
                    {
                        query = query.Include(includeProperty.Trim());
                    }
                    else
                    {
                        Console.WriteLine($"Geçersiz include path: '{includeProperty}' - bu property bulunamadı ve yok sayıldı.");
                    }
                }
            }
            var appointments = query.ToList();
            var appointmentViewModels = appointments.Select(r => new AppointmentViewModel(r)).ToList();
            return appointmentViewModels;
        }

        public AppointmentViewModel GetAppoinmentGetById(int AppointmentId)
        {
            var appoinment = _context.Appointments.Find(AppointmentId);
            if (appoinment == null)
            {
                return null;
            }
            return new AppointmentViewModel(appoinment);
        }

        public void UpdateAppointment(AppointmentViewModel appointmentlViewModel)
        {
            var exitingAppointment = _context.Appointments.Find(appointmentlViewModel.Id);
            if (exitingAppointment == null)
            {
                throw new KeyNotFoundException("Appointment not found.");
            }
            exitingAppointment.StartTime = DateTime.Now;
            exitingAppointment.EndTime = DateTime.Now;
            exitingAppointment.Description = appointmentlViewModel.Description;
            exitingAppointment.Status = appointmentlViewModel.Status;
            exitingAppointment.DoctorId = appointmentlViewModel.DoctorId;
            exitingAppointment.PatientId = appointmentlViewModel.PatientId;
            exitingAppointment.HospitalId = appointmentlViewModel.HospitalId;

            _context.Appointments.Update(exitingAppointment);
            _context.SaveChanges();
        }
    }
    }

