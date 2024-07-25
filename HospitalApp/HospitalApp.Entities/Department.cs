using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApp.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? HospitalId { get; set; }

        public HospitalInfo Hospital{ get; set; }
    }
}
