using Hospital.Models;
using HospitalApp.DataAccess.Abstract;
using HospitalApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalApp.DataAccess.Concrete
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateDepartment(DepartmentViewModel departmentViewModel)
        {
            var department = departmentViewModel.ConvertViewModel(departmentViewModel);
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var deleteDepartment = _context.Departments.Find(id);
            if (deleteDepartment == null)
            {
                throw new KeyNotFoundException("Department not found.");
            }
            _context.Departments.Remove(deleteDepartment);
            _context.SaveChanges();
        }

        public List<DepartmentViewModel> GetAll()
        {
            var departments = _context.Departments.ToList();
            var departmentViewModel = departments.Select(h => new DepartmentViewModel(h)).ToList();
            return departmentViewModel;
        }

        public List<DepartmentViewModel> GetAll(string IncludeProperties)
        {
            IQueryable<Department> query = _context.Departments;

            foreach (var includeProperty in IncludeProperties.Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            var deparments = query.ToList();
            var departmentViewModels = deparments.Select(r => new DepartmentViewModel(r)).ToList();
            return departmentViewModels;
        }
    

        public DepartmentViewModel GetDepartmentById(int DepartmentId)
        {
            var department = _context.Departments.Find(DepartmentId);
            if (department == null)
            {
                return null;
            }
            return new DepartmentViewModel(department);
        }

        public void UpdateDepartment(DepartmentViewModel departmentViewModel)
        {
            var existingDepartments = _context.Departments.Find(departmentViewModel.Id);
            if (existingDepartments == null)
            {
                throw new KeyNotFoundException("Department not found.");
            }

            existingDepartments.Name = departmentViewModel.Name;
            existingDepartments.Description = departmentViewModel.Description;
            existingDepartments.HospitalId = departmentViewModel.HospitalId;

            _context.Departments.Update(existingDepartments);
            _context.SaveChanges();
        }
    }
    }


