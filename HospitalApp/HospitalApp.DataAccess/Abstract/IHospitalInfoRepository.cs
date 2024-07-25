using Hospital.Models;
using HospitalApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApp.DataAccess.Abstract
{
    public interface IHospitalInfoRepository
    {
        List<HospitalViewModel> GetAll();

        HospitalViewModel GetHospitalById(int HospitalId);

        void UpdateHospital(HospitalViewModel hospitalViewModel); 

        void CreateHospital(HospitalViewModel hospitalViewModel);   

        void DeleteHospital( int id );  

    }
}
