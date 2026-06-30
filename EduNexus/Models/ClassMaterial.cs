using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class ClassMaterial
{
    public long Id { get; set; }

    public long ClassId { get; set; }

    public long TeacherId { get; set; }

    public string Title { get; set; } = null!;

    public string? Body { get; set; }

    public string? FileUrl { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual User Teacher { get; set; } = null!;
}
