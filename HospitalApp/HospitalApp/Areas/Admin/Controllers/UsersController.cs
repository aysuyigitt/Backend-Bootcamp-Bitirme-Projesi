using HospitalApp.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
      
            private readonly IApplicationUserRepository _userRepository;
        

            public UsersController(IApplicationUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public IActionResult Index()
            {
            var users = _userRepository.GetAllHospitals(); 
            return View(users); 
        }

      
        }
    }
