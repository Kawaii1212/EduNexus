using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class KnowledgeGapAnalysis
{
    public long Id { get; set; }

    public long StudentId { get; set; }

    public string? WeakTopics { get; set; }

    public string? Roadmap { get; set; }

    public DateTimeOffset GeneratedAt { get; set; }

    public DateTimeOffset CacheExpiresAt { get; set; }

    public virtual User Student { get; set; } = null!;
}
