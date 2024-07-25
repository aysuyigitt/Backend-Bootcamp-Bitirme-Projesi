using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApp.DataAccess.Abstract
{
    public interface IAppointmentRepository
    {
        List<AppointmentViewModel> GetAll(string v);

        AppointmentViewModel GetAppoinmentGetById(int AppointmentId);

        void UpdateAppointment(AppointmentViewModel appointmentlViewModel);

        void CreateAppointment(AppointmentViewModel appointmentViewModel);

        void DeleteAppointment(int id);
    }
}
    

