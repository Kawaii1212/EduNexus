using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Submission
{
    public long Id { get; set; }

    public long AssignmentId { get; set; }

    public long StudentId { get; set; }

    public string? Content { get; set; }

    public string? FileUrl { get; set; }

    public decimal? FinalScore { get; set; }

    public decimal? AiScore { get; set; }

    public string? Feedback { get; set; }

    public string Status { get; set; } = null!;

    public long? GradedBy { get; set; }

    public DateTimeOffset? GradedAt { get; set; }

    public DateTimeOffset SubmittedAt { get; set; }

    public virtual Assignment Assignment { get; set; } = null!;

    public virtual User? GradedByNavigation { get; set; }

    public virtual User Student { get; set; } = null!;

    public virtual ICollection<SubmissionCriterionScore> SubmissionCriterionScores { get; set; } = new List<SubmissionCriterionScore>();
}
