using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public class QuizHistoryItemViewModel
{
    public long QuizAttemptId { get; set; }
    public string QuizTitle { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public DateTimeOffset DateTaken { get; set; }
    public decimal? Score { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class QuizHistoryViewModel
{
    public int QuizzesTaken { get; set; }
    public decimal AverageScore { get; set; }
    public int PassedCount { get; set; }
    public int FailedCount { get; set; }
    public List<QuizHistoryItemViewModel> Attempts { get; set; } = new List<QuizHistoryItemViewModel>();
}
