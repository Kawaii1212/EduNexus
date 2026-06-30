using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class VContentQualityReport
{
    public long LessonId { get; set; }

    public string LessonTitle { get; set; } = null!;

    public long CourseId { get; set; }

    public int? ViewCount { get; set; }

    public double? AvgWatchSeconds { get; set; }

    public decimal? DropRate { get; set; }
}
