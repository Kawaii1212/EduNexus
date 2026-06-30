using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class Enrollment
{
    public long Id { get; set; }

    public long StudentId { get; set; }

    public string EnrollmentType { get; set; } = null!;

    public long? CourseId { get; set; }

    public long? ClassId { get; set; }

    public long? SubscriptionPackageId { get; set; }

    public string Status { get; set; } = null!;

    public DateTimeOffset EnrolledAt { get; set; }

    public DateTimeOffset? ExpiresAt { get; set; }

    public decimal ProgressPercent { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User Student { get; set; } = null!;

    public virtual SubscriptionPackage? SubscriptionPackage { get; set; }
}
