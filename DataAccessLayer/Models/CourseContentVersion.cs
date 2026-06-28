using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class CourseContentVersion
{
    public long Id { get; set; }

    public long CourseId { get; set; }

    public int VersionNo { get; set; }

    public string SnapshotJson { get; set; } = null!;

    public long? ChangedBy { get; set; }

    public string? ChangeNote { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual User? ChangedByNavigation { get; set; }

    public virtual Course Course { get; set; } = null!;
}
