using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class AuditLog
{
    public long Id { get; set; }

    public long? ActorId { get; set; }

    public string ActionType { get; set; } = null!;

    public string ResourceType { get; set; } = null!;

    public long? ResourceId { get; set; }

    public string? Metadata { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual User? Actor { get; set; }
}
