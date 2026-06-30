using EduNexus.ViewModels;
using EduNexus.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EduNexus.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EduNexus.Controllers
{
    public class CommonController : Controller
    {
        private readonly ILogger<CommonController> _logger;
        private readonly IClassMaterialService _classMaterialService;
        private readonly IProgressService _progressService;
        private readonly IUserService _userService;

        public CommonController(
            ILogger<CommonController> logger, 
            IClassMaterialService classMaterialService, 
            IProgressService progressService,
            IUserService userService)
        {
            _logger = logger;
            _classMaterialService = classMaterialService;
            _progressService = progressService;
            _userService = userService;
        }

        public IActionResult CourseList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            // If already authenticated, redirect based on role
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Student") || User.IsInRole("STUDENT"))
                {
                    return RedirectToAction("StudentLibrary", "Common");
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userService.GetUserByEmail(model.Email);
            
            if (user == null || user.PasswordHash != model.Password)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(model);
            }

            if (user.Status != "Active" && user.Status != "active")
            {
                ModelState.AddModelError(string.Empty, "Your account is not active.");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Role, user.Role ?? "")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                authProperties);

            if (user.Role?.Equals("Student", StringComparison.OrdinalIgnoreCase) == true)
            {
                return RedirectToAction("StudentLibrary", "Common");
            }
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("UserLogin", "Common");
        }

        [HttpGet]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, Microsoft.AspNetCore.Authentication.Google.GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            if (!result.Succeeded)
            {
                result = await HttpContext.AuthenticateAsync(Microsoft.AspNetCore.Authentication.Google.GoogleDefaults.AuthenticationScheme);
                if (!result.Succeeded)
                {
                    return RedirectToAction("UserLogin", "Common");
                }
            }

            var claims = result.Principal.Identities.FirstOrDefault()?.Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });

            if (claims == null) return RedirectToAction("UserLogin", "Common");

            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var nameIdentifier = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nameIdentifier))
            {
                return RedirectToAction("UserLogin", "Common");
            }

            var user = _userService.HandleGoogleLogin(email, name ?? "Google User", nameIdentifier);

            var appClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Role, user.Role ?? "")
            };

            var identity = new ClaimsIdentity(appClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (user.Role?.Equals("Student", StringComparison.OrdinalIgnoreCase) == true)
            {
                return RedirectToAction("StudentLibrary", "Common");
            }
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CourseStructure()
        {
            return View();
        }

        public IActionResult PersonalProgress()
        {
            var studentIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (studentIdClaim == null) return RedirectToAction("UserLogin", "Common");
            
            long studentId = long.Parse(studentIdClaim.Value);
            
            var enrollments = _progressService.GetEnrollmentsByStudent(studentId);
            var learningProgresses = _progressService.GetLearningProgressesByStudent(studentId);

            int totalSeconds = 0;
            var activeDates = new System.Collections.Generic.HashSet<string>();

            foreach(var lp in learningProgresses)
            {
                totalSeconds += lp.TimeSpentSeconds;
                activeDates.Add(lp.LastActiveAt.ToString("yyyy-MM-dd"));
            }

            var viewModel = new PersonalProgressViewModel
            {
                CoursesEnrolled = System.Linq.Enumerable.Count(enrollments),
                CoursesCompleted = System.Linq.Enumerable.Count(enrollments, e => e.ProgressPercent >= 100 || e.Status == "Completed"),
                LearningHours = totalSeconds / 3600,
                CurrentStreak = activeDates.Count 
            };

            string[] defaultIcons = { "fa-react", "fa-node-js", "fa-docker", "fa-python", "fa-java" };
            string[] defaultColors = { "#3b82f6", "#10b981", "#3b82f6", "#f59e0b", "#ef4444" };
            int i = 0;

            foreach (var e in enrollments)
            {
                if (e.ProgressPercent < 100)
                {
                    var actualCourse = e.Course ?? e.Class?.Course;
                    if (actualCourse != null)
                    {
                        viewModel.OngoingCourses.Add(new OngoingCourseViewModel
                        {
                            CourseId = actualCourse.Id,
                            CourseName = actualCourse.Title,
                            CurrentModuleOrLesson = e.Class != null ? "Enrolled in Class: " + e.Class.Name : "Self-paced Course", 
                            ProgressPercent = e.ProgressPercent,
                            IconClass = "fa-brands " + defaultIcons[i % defaultIcons.Length],
                            IconColorHex = defaultColors[i % defaultColors.Length]
                        });
                        i++;
                    }
                }
            }

            return View(viewModel);
        }

        public IActionResult StudentLibrary()
        {
            var studentIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (studentIdClaim == null) return RedirectToAction("UserLogin", "Common");
            
            long studentId = long.Parse(studentIdClaim.Value);
            var materials = _classMaterialService.GetMaterialsByStudentId(studentId);
            
            var viewModel = new StudentLibraryViewModel();
            foreach (var material in materials)
            {
                viewModel.Resources.Add(new ResourceItemViewModel
                {
                    Id = material.Id,
                    Title = material.Title,
                    Description = material.Body ?? "No description provided.",
                    FileUrl = material.FileUrl ?? "#",
                    FileSize = "Unknown Size" 
                });
            }

            return View(viewModel);
        }
    }
}
