using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Notification
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string Type { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Message { get; set; }

    public bool IsRead { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
