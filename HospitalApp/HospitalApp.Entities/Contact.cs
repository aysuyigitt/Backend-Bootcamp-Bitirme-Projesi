using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApp.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? HospitalId { get; set; }

        public HospitalInfo Hospital { get; set; }
    }
}
