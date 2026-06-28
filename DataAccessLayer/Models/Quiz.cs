using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Quiz
{
    public long Id { get; set; }

    public long CourseId { get; set; }

    public long? CreatedBy { get; set; }

    public string Name { get; set; } = null!;

    public string Difficulty { get; set; } = null!;

    public int QuestionCount { get; set; }

    public string Status { get; set; } = null!;

    public bool IsPracticeGenerated { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
}
