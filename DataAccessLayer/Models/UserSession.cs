using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class UserSession
{
    public Guid Id { get; set; }

    public long UserId { get; set; }

    public string RefreshTokenHash { get; set; } = null!;

    public string? DeviceInfo { get; set; }

    public DateTimeOffset IssuedAt { get; set; }

    public DateTimeOffset ExpiresAt { get; set; }

    public DateTimeOffset? RevokedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
