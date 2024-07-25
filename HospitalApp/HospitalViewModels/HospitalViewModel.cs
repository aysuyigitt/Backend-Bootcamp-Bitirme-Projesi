using HospitalApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models
{
    public class HospitalViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public HospitalViewModel( ) { }

            public HospitalViewModel(HospitalInfo model)
            {
                Id = model.Id;
                Name = model.Name;
                Type = model.Type;
                Country = model.Country;
                City = model.City;
                    
            }
            public HospitalInfo ConvertViewModel(HospitalViewModel model)
            {
                return new HospitalInfo
                {
                    Id = model.Id,
                    Name = model.Name,
                    Type = model.Type,
                    Country = model.Country,    
                    City = model.City
                };
            }

        }
    }


