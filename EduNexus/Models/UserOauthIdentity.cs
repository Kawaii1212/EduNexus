using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class UserOauthIdentity
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string Provider { get; set; } = null!;

    public string ProviderUserId { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
