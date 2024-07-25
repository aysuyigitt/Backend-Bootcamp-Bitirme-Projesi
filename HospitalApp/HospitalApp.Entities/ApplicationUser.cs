
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApp.Entities
{
    public class ApplicationUser:IdentityUser
    {
     public int Id { get; set; }

     public String Name { get; set; }
     
     public string Adress {  get; set; }

     public string City {  get; set; }  

     public DateTime DOB { get; set; }

     public string Specialist { get; set; } 

     public Department Department {  get; set; }

     public string ImageUrl { get; set; }

     
     public ICollection<Appointment> Appointments { get; set; }
     public ICollection<Appointment> DoctorAppointments { get; set; }
     public ICollection<Appointment> PatientAppointments { get; set; }
    }
}

