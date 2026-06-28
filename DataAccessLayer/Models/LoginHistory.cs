using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class LoginHistory
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public DateTimeOffset LoginAt { get; set; }

    public string Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
