using EduNexus.ViewModels;
using System;
using Microsoft.AspNetCore.Mvc;
using EduNexus.Services;
using EduNexus.Models;

namespace EduNexus.Controllers;

public class GradingController : Controller
{
    private readonly ISubmissionService _submissionService;

    public GradingController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var submissions = _submissionService.GetAllSubmissions();
        var model = submissions.Select(s => new SubmissionListViewModel
        {
            SubmissionId = s.Id,
            StudentName = s.Student?.FullName ?? "Unknown",
            AssignmentTitle = s.Assignment?.Title ?? "Unknown",
            AiScore = s.AiScore,
            FinalScore = s.FinalScore,
            Status = s.Status,
            SubmittedAt = s.SubmittedAt
        }).ToList();

        return View(model);
    }


    [HttpGet]
    public IActionResult Grade(long submissionId)
    {
        try
        {
            var submission = _submissionService.GetSubmissionForGrading(submissionId);
            
            var model = new GradingViewModel
            {
                SubmissionId = submission.Id,
                StudentName = submission.Student?.FullName ?? "Unknown Student",
                AssignmentTitle = submission.Assignment?.Title ?? "Unknown Assignment",
                Content = submission.Content,
                FileUrl = submission.FileUrl,
                AiFeedback = submission.Feedback,
                AiScore = submission.AiScore,
                FinalScore = submission.FinalScore,
                Status = submission.Status
            };

            return View(model);
        }
        catch (Exception ex)
        {
            // Log exception here if logging is set up
            return NotFound("Submission not found or error occurred: " + ex.Message);
        }
    }

    [HttpPost]
    public IActionResult UpdateScore([FromBody] UpdateScoreRequest request)
    {
        if (request == null || request.SubmissionId <= 0 || request.Score < 0)
        {
            return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ." });
        }

        try
        {
            // Mock Teacher Id for now since Auth is not fully implemented
            long teacherId = 2; // Assuming 2 is a valid teacher ID
            
            _submissionService.GradeSubmission(request.SubmissionId, request.Score, teacherId);
            
            return Ok(new { success = true, message = "Lưu điểm thành công!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, message = "Lỗi hệ thống: " + ex.Message });
        }
    }
}
