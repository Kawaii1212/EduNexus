using EduNexus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EduNexus.Services;

namespace EduNexus.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult SignUp()
        {
            return View();
        }
    }
}
