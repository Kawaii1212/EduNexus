using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Question
{
    public long Id { get; set; }

    public long ModuleId { get; set; }

    public string Content { get; set; } = null!;

    public string OptionA { get; set; } = null!;

    public string OptionB { get; set; } = null!;

    public string OptionC { get; set; } = null!;

    public string OptionD { get; set; } = null!;

    public string CorrectOption { get; set; } = null!;

    public string Difficulty { get; set; } = null!;

    public string? AiExplanation { get; set; }

    public string Source { get; set; } = null!;

    public string Status { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public long? ApprovedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual User? ApprovedByNavigation { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual ICollection<QuizAttemptAnswer> QuizAttemptAnswers { get; set; } = new List<QuizAttemptAnswer>();

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
}
