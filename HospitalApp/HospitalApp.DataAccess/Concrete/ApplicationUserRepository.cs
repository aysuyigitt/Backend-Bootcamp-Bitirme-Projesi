using Hospital.Models;

using HospitalApp.DataAccess.Abstract;
using HospitalApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalApp.DataAccess.Concrete
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;


        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public List<ApplicationUserViewModel> GetAllDoctor()
        {
            var users = _context.Users
              .OfType<ApplicationUser>()
              .ToList();

            var userViewModels = users.Select(u => new ApplicationUserViewModel(u)).ToList();
            return userViewModels;
        }


        public List<ApplicationUserViewModel> GetAllHospitals()
        {
            var users = _context.Users
              .OfType<ApplicationUser>()
              .ToList();

            var userViewModels = users.Select(u => new ApplicationUserViewModel(u)).ToList();
            return userViewModels;
        }



        public List<ApplicationUserViewModel> GetAllPatient()
        {
            var users = _context.Users
              .OfType<ApplicationUser>()
              .ToList();

            var userViewModels = users.Select(u => new ApplicationUserViewModel(u)).ToList();
            return userViewModels;

        }
    }
    }
