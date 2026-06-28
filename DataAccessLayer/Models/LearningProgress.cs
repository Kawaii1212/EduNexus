using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class LearningProgress
{
    public long Id { get; set; }

    public long StudentId { get; set; }

    public long? ClassId { get; set; }

    public long? LessonId { get; set; }

    public string ActivityType { get; set; } = null!;

    public string CompletionStatus { get; set; } = null!;

    public decimal? Score { get; set; }

    public int TimeSpentSeconds { get; set; }

    public int AttemptCount { get; set; }

    public DateTimeOffset LastActiveAt { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual User Student { get; set; } = null!;
}
