using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Payment
{
    public long Id { get; set; }

    public long EnrollmentId { get; set; }

    public long UserId { get; set; }

    public decimal Amount { get; set; }

    public string Gateway { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? TransactionRef { get; set; }

    public DateTimeOffset? PaidAt { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;

    public virtual ICollection<RefundRequest> RefundRequests { get; set; } = new List<RefundRequest>();

    public virtual User User { get; set; } = null!;
}
