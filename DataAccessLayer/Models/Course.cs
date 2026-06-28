using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Course
{
    public long Id { get; set; }

    public long CourseGroupId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string Status { get; set; } = null!;

    public int Version { get; set; }

    public long? CreatedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<CourseContentVersion> CourseContentVersions { get; set; } = new List<CourseContentVersion>();

    public virtual CourseGroup CourseGroup { get; set; } = null!;

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<FlashcardDeck> FlashcardDecks { get; set; } = new List<FlashcardDeck>();

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
