using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace HospitalApp.Entities
{
    public class HospitalInfo
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public ICollection<Department> Departments { get; set; } 
        public ICollection<Contact> Contacts { get; set; } 
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Appointment> Appointments { get; set; } 
       

    }
}
