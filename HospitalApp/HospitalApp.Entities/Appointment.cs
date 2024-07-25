using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApp.Entities
{
    public class Appointment
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
        public HospitalInfo Hospital { get; set; }

    }
}
