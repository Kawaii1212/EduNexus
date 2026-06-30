using System;
using EduNexus.Models;
using EduNexus.Repositories;

namespace EduNexus.Services;

public class SubmissionService : ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;

    public SubmissionService(ISubmissionRepository submissionRepository)
    {
        _submissionRepository = submissionRepository;
    }

    public void SubmitEssay(long assignmentId, long studentId, string content, string? fileUrl)
    {
        var existingSubmission = _submissionRepository.GetSubmissionByAssignmentAndStudent(assignmentId, studentId);

        if (existingSubmission != null)
        {
            // Resubmit: Update existing record
            existingSubmission.Content = content;
            if (fileUrl != null)
            {
                existingSubmission.FileUrl = fileUrl;
            }
            existingSubmission.SubmittedAt = DateTimeOffset.UtcNow;
            existingSubmission.Status = "SUBMITTED"; // Ensure status is SUBMITTED for AI to pick up
            
            _submissionRepository.UpdateSubmission(existingSubmission);
        }
        else
        {
            // New submission
            var newSubmission = new Submission
            {
                AssignmentId = assignmentId,
                StudentId = studentId,
                Content = content,
                FileUrl = fileUrl,
                SubmittedAt = DateTimeOffset.UtcNow,
                Status = "SUBMITTED" // DO NOT USE "Pending_AI_Review" as it violates DB Constraint
            };

            _submissionRepository.AddSubmission(newSubmission);
        }
    }

    public Submission GetSubmissionForGrading(long submissionId)
    {
        var submission = _submissionRepository.GetSubmissionById(submissionId);
        if (submission == null)
        {
            throw new Exception("Submission not found.");
        }
        return submission;
    }

    public void GradeSubmission(long submissionId, decimal finalScore, long teacherId)
    {
        var submission = _submissionRepository.GetSubmissionById(submissionId);
        if (submission == null)
        {
            throw new Exception("Submission not found.");
        }

        submission.FinalScore = finalScore;
        submission.GradedBy = teacherId;
        submission.GradedAt = DateTimeOffset.UtcNow;
        submission.Status = "GRADED";

        _submissionRepository.UpdateSubmission(submission);
    }

    public List<Submission> GetAllSubmissions()
    {
        return _submissionRepository.GetAllSubmissions();
    }
}
