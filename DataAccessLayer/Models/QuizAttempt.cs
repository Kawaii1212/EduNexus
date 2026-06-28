using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class QuizAttempt
{
    public long Id { get; set; }

    public long QuizId { get; set; }

    public long StudentId { get; set; }

    public DateTimeOffset StartTime { get; set; }

    public DateTimeOffset? SubmitTime { get; set; }

    public decimal? Score { get; set; }

    public string Status { get; set; } = null!;

    public virtual Quiz Quiz { get; set; } = null!;

    public virtual ICollection<QuizAttemptAnswer> QuizAttemptAnswers { get; set; } = new List<QuizAttemptAnswer>();

    public virtual User Student { get; set; } = null!;
}
