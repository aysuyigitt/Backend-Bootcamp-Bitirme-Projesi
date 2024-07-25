using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApp.DataAccess.Abstract
{
    public interface IDepartmentRepository
    {
        List<DepartmentViewModel> GetAll(string IncludeProperties);

        DepartmentViewModel GetDepartmentById(int DepartmentId);

        void UpdateDepartment(DepartmentViewModel departmentViewModel);

        void CreateDepartment(DepartmentViewModel departmentViewModel);

        void DeleteDepartment(int id);
    }
}
