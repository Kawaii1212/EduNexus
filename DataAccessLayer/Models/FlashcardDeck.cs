using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class FlashcardDeck
{
    public long Id { get; set; }

    public long CourseId { get; set; }

    public long? ModuleId { get; set; }

    public string Name { get; set; } = null!;

    public string? Category { get; set; }

    public string Status { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Flashcard> Flashcards { get; set; } = new List<Flashcard>();

    public virtual Module? Module { get; set; }
}
