using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Flashcard
{
    public long Id { get; set; }

    public long DeckId { get; set; }

    public string FrontText { get; set; } = null!;

    public string BackText { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public virtual FlashcardDeck Deck { get; set; } = null!;

    public virtual ICollection<FlashcardReviewLog> FlashcardReviewLogs { get; set; } = new List<FlashcardReviewLog>();
}
