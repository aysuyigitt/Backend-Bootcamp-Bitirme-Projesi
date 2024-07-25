using HospitalApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? HospitalId { get; set; }

        public HospitalInfo HospitalInfo { get; set; }

        public DepartmentViewModel() { }

        public DepartmentViewModel(Department model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            HospitalId = model.HospitalId;
            HospitalInfo = model.Hospital;
            
        }
        public Department ConvertViewModel(DepartmentViewModel model)
        {
            return new Department {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                HospitalId = model.HospitalId
        };
        }
        }
}
