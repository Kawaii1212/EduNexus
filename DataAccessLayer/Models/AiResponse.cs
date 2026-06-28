using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class AiResponse
{
    public long Id { get; set; }

    public long AiRequestId { get; set; }

    public string Model { get; set; } = null!;

    public string? GeneratedContent { get; set; }

    public int TokenConsumed { get; set; }

    public int? ProcessingTimeMs { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual AiRequest AiRequest { get; set; } = null!;
}
