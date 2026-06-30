using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class AssignmentRubricCriterion
{
    public long Id { get; set; }

    public long AssignmentId { get; set; }

    public string Name { get; set; } = null!;

    public decimal MaxScore { get; set; }

    public decimal WeightPercent { get; set; }

    public int OrderNo { get; set; }

    public virtual Assignment Assignment { get; set; } = null!;

    public virtual ICollection<SubmissionCriterionScore> SubmissionCriterionScores { get; set; } = new List<SubmissionCriterionScore>();
}
