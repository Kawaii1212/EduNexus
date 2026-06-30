namespace EduNexus.ViewModels;

public class GradingViewModel
{
    public long SubmissionId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string AssignmentTitle { get; set; } = string.Empty;
    
    // Content can be HTML or plain text
    public string? Content { get; set; }
    public string? FileUrl { get; set; }
    
    public string? AiFeedback { get; set; }
    public decimal? AiScore { get; set; }
    public decimal? FinalScore { get; set; }
    
    public string Status { get; set; } = string.Empty;
}

public class UpdateScoreRequest
{
    public long SubmissionId { get; set; }
    public decimal Score { get; set; }
}
