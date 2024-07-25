using HospitalApp.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Hospital.Models
{
    public class ApplicationUserViewModel
    {
        public int Id { get; set; }

        public String UserName { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public DateTime DOB { get; set; }

        public string Specialist { get; set; }

        public Department Department { get; set; }

        public string ImageUrl { get; set; }

  
        public ApplicationUserViewModel(Microsoft.AspNetCore.Identity.IdentityUser u) { }

        public ApplicationUserViewModel(ApplicationUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Adress = user.Adress;
            City = user.City;
            DOB = user.DOB;
            Specialist = user.Specialist;
            ImageUrl = user.ImageUrl;
        }
        public ApplicationUser ConvertViewModel(ApplicationUserViewModel user)
        {
            return new ApplicationUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Adress = user.Adress,
                City = user.City,
                DOB = user.DOB,
                Specialist = user.Specialist,
                ImageUrl = user.ImageUrl,
        };
        }
    }
}
