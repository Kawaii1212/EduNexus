using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class FlashcardReviewLog
{
    public long Id { get; set; }

    public long FlashcardId { get; set; }

    public long StudentId { get; set; }

    public string MemoryState { get; set; } = null!;

    public DateTimeOffset ReviewedAt { get; set; }

    public DateTimeOffset? NextReviewAt { get; set; }

    public virtual Flashcard Flashcard { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
