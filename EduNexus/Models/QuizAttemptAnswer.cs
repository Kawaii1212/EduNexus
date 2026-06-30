using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class QuizAttemptAnswer
{
    public long Id { get; set; }

    public long AttemptId { get; set; }

    public long QuestionId { get; set; }

    public string? SelectedOption { get; set; }

    public bool? IsCorrect { get; set; }

    public virtual QuizAttempt Attempt { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
