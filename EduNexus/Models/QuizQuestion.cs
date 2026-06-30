using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class QuizQuestion
{
    public long Id { get; set; }

    public long QuizId { get; set; }

    public long QuestionId { get; set; }

    public int OrderNo { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual Quiz Quiz { get; set; } = null!;
}
