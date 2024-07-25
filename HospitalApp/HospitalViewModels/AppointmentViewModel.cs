using HospitalApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string? DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }

        public string? PatientId { get; set; }
        public ApplicationUser Patient { get; set; }

        public int? HospitalId { get; set; }
        public HospitalInfo HospitalInfo { get; }
        public HospitalInfo Hospital { get; set; }

        public AppointmentViewModel() { }

        public AppointmentViewModel(Appointment model)
        {
            Id = model.Id;
            StartTime = model.StartTime;
            EndTime = model.EndTime;
            Description = model.Description;
            Status = model.Status;
            DoctorId = model.DoctorId;
            PatientId = model.PatientId;
            HospitalId = model.HospitalId;
            HospitalInfo = model.Hospital;
        }

        public Appointment ConvertViewModel(AppointmentViewModel model)
        {
            return new Appointment
            {
                Id = model.Id,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Description = model.Description,
                Status = model.Status,
                DoctorId = model.DoctorId,
                PatientId = model.PatientId,
                HospitalId = model.HospitalId

            };
        }
    }
}
    

