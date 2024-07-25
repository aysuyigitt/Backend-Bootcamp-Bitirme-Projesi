using HospitalApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        public string? RoomNumber { get; set; }

        public string? Type { get; set; }

        public string? Status { get; set; }

        public int? HospitalId { get; set; }

        public HospitalInfo HospitalInfo { get; set; }  

        public RoomViewModel() { }

        public RoomViewModel(Room model)
        {
            Id = model.Id;
            RoomNumber = model.RoomNumber;  
            Type = model.Type;
            Status = model.Status;
            HospitalId = model.HospitalId;
            HospitalInfo = model.Hospital;           
        }
        public Room ConvertViewModel(RoomViewModel model)
        {
            return new Room
            {
                Id = model.Id,
                RoomNumber = model.RoomNumber,
                Type = model.Type,
                Status = model.Status,
                HospitalId = model.HospitalId,
            
        };
        }

    }
}
