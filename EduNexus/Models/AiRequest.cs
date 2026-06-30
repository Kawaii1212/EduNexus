using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class AiRequest
{
    public long Id { get; set; }

    public long RequesterId { get; set; }

    public string TaskType { get; set; } = null!;

    public string? SourceRefType { get; set; }

    public long? SourceRefId { get; set; }

    public string Status { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public virtual AiResponse? AiResponse { get; set; }

    public virtual User Requester { get; set; } = null!;
}
