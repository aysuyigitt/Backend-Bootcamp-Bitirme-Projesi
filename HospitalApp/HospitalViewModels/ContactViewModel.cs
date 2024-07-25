using HospitalApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? HospitalId { get; set; }

        public HospitalInfo HospitalInfo { get; set; }


        public ContactViewModel() { }

        public ContactViewModel(Contact model)
        {
            Id = model.Id;
            Email = model.Email;
            Phone = model.Phone;
            HospitalId = model.HospitalId;
            HospitalInfo = model.Hospital;
        }
        public Contact ConvertViewModel(ContactViewModel model)
        {
            return new Contact
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                HospitalId = model.HospitalId
            };
        }

    }
}
