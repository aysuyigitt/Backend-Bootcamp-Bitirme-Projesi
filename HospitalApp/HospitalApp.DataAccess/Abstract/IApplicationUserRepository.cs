using Hospital.Models;
using HospitalApp.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalApp.DataAccess.Abstract
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUserViewModel> GetAllHospitals();

        List<ApplicationUserViewModel> GetAllDoctor();

        List<ApplicationUserViewModel> GetAllPatient();
    }
}
