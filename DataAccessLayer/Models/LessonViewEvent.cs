using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class LessonViewEvent
{
    public long Id { get; set; }

    public long LessonId { get; set; }

    public long StudentId { get; set; }

    public DateTimeOffset ViewedAt { get; set; }

    public int WatchSeconds { get; set; }

    public bool Completed { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
