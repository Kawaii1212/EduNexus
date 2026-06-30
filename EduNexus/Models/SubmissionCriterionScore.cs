using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class SubmissionCriterionScore
{
    public long Id { get; set; }

    public long SubmissionId { get; set; }

    public long CriterionId { get; set; }

    public decimal? AiScore { get; set; }

    public decimal? FinalScore { get; set; }

    public string? AiFeedback { get; set; }

    public string? TeacherFeedback { get; set; }

    public virtual AssignmentRubricCriterion Criterion { get; set; } = null!;

    public virtual Submission Submission { get; set; } = null!;
}
