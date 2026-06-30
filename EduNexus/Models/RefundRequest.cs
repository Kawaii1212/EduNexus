using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class RefundRequest
{
    public long Id { get; set; }

    public long PaymentId { get; set; }

    public long StudentId { get; set; }

    public string Reason { get; set; } = null!;

    public string Status { get; set; } = null!;

    public long? ReviewedBy { get; set; }

    public DateTimeOffset? ReviewedAt { get; set; }

    public DateTimeOffset? RefundedAt { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual User? ReviewedByNavigation { get; set; }

    public virtual User Student { get; set; } = null!;
}
