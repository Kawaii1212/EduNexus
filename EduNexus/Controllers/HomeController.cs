using EduNexus.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EduNexus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataAccessLayer.Services.IQuizAttemptService _quizAttemptService;

        public HomeController(ILogger<HomeController> logger, DataAccessLayer.Services.IQuizAttemptService quizAttemptService)
        {
            _logger = logger;
            _quizAttemptService = quizAttemptService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CourseStructure()
        {
            return View();
        }

        public IActionResult EditLesson()
        {
            return View();
        }

        public IActionResult QuizBuilder()
        {
            return View();
        }

        public IActionResult PersonalProgress()
        {
            return View();
        }

        public IActionResult StudentLibrary()
        {
            return View();
        }

        public IActionResult LessonView()
        {
            return View();
        }

        public IActionResult FlashcardLibrary()
        {
            return View();
        }

        public IActionResult QuizHistory()
        {
            long studentId = 2; // Mock Student ID
            var attempts = _quizAttemptService.GetHistoryForStudent(studentId);

            var model = new QuizHistoryViewModel();
            model.QuizzesTaken = attempts.Count;
            
            if (attempts.Any(a => a.Score.HasValue))
            {
                model.AverageScore = attempts.Where(a => a.Score.HasValue).Average(a => a.Score.Value);
            }

            model.PassedCount = attempts.Count(a => a.Status == "PASSED");
            model.FailedCount = attempts.Count(a => a.Status == "FAILED");

            model.Attempts = attempts.Select(a => new QuizHistoryItemViewModel
            {
                QuizAttemptId = a.Id,
                QuizTitle = a.Quiz?.Name ?? "Unknown Quiz",
                CourseName = a.Quiz?.Course?.Title ?? "Unknown Course",
                DateTaken = a.StartTime,
                Score = a.Score,
                Status = a.Status
            }).ToList();

            return View(model);
        }

        public IActionResult QuizTaking()
        {
            return View();
        }

        public IActionResult QuizResults()
        {
            return View();
        }

        public IActionResult QuizReview()
        {
            return View();
        }

        public IActionResult EssaySubmit()
        {
            return RedirectToAction("SubmitEssay", "Assignment", new { assignmentId = 1 });
        }

        public IActionResult EssayResults()
        {
            return View();
        }

        public IActionResult AILessonStaging()
        {
            return View();
        }

        public IActionResult AssignmentList()
        {
            return View();
        }

        public IActionResult AssignmentDetail()
        {
            return View();
        }

        public IActionResult AIAssignmentStaging()
        {
            return View();
        }

        public IActionResult QuestionDetail()
        {
            return View();
        }

        public IActionResult AIQuestionStaging()
        {
            return View();
        }

        public IActionResult FlashcardEditor()
        {
            return View();
        }

        public IActionResult AIFlashcardStaging()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
