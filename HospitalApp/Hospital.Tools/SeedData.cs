using HospitalApp.DataAccess;
using HospitalApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Tools
{
    public class SeedData : ISeedData
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            if (_context.Database.GetPendingMigrations().Count() > 0)
            {
                _context.Database.Migrate();
            }
            if (!_roleManager.RoleExistsAsync(WebRoles.Web_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebRoles.Web_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebRoles.Web_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebRoles.Web_Doctor)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Aysu",
                    Email = "Aysu@gmil.com"
                }, "Aysu@123").GetAwaiter().GetResult();
                var Appuser = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "Aysu@gmil.com");
                if (Appuser != null)
                {
                    _userManager.AddToRoleAsync(Appuser, WebRoles.Web_Admin).GetAwaiter().GetResult();
                }

            }

        }
    }
}
/*Veritabanı Geçişlerini Uygulama: Veritabanında bekleyen geçişler olup olmadığını kontrol eder ve varsa uygular.
Rol Kontrolü ve Oluşturma: Web_Admin rolünün var olup olmadığını kontrol eder. Yoksa, Web_Admin ve Web_Doctor rollerini oluşturur.
Kullanıcı Oluşturma ve Rol Atama: "Aysu" kullanıcı adında ve "Aysu@gmil.com" e-posta adresinde bir kullanıcı oluşturur. Bu kullanıcıyı Web_Admin rolüne atar.
Bu işlemler, uygulamanın ilk kez başlatıldığında veritabanının doğru yapılandırılmasını ve gerekli başlangıç verilerinin oluşturulmasını sağlar.*/







