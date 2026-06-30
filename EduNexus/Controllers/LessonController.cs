using EduNexus.ViewModels;
using EduNexus.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduNexus.Controllers
{
    public class LessonController : Controller
    {
        public IActionResult LessonEditor()
        {
            return View();
        }

        public IActionResult AILessonStaging()
        {
            return View();
        }

        public IActionResult LessonView()
        {
            return View();
        }

        public IActionResult LessonTextExtract()
        {
            return View();
        }
    }
}
