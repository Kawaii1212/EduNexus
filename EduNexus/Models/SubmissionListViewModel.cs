using System;

namespace EduNexus.Models;

public class SubmissionListViewModel
{
    public long SubmissionId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string AssignmentTitle { get; set; } = string.Empty;
    public decimal? AiScore { get; set; }
    public decimal? FinalScore { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset SubmittedAt { get; set; }
}
