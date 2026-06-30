using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class BackgroundJobLog
{
    public long Id { get; set; }

    public string JobName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTimeOffset StartedAt { get; set; }

    public DateTimeOffset? FinishedAt { get; set; }

    public string? ErrorMessage { get; set; }
}
