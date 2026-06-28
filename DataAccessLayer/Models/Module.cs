using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Module
{
    public long Id { get; set; }

    public long CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int OrderNo { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<FlashcardDeck> FlashcardDecks { get; set; } = new List<FlashcardDeck>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
