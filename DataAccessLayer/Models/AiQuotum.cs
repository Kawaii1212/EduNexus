using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class AiQuotum
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string MonthYear { get; set; } = null!;

    public int QuotaLimit { get; set; }

    public int UsedCount { get; set; }

    public virtual User User { get; set; } = null!;
}
