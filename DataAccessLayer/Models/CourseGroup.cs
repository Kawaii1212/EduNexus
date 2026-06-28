using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class CourseGroup
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual ICollection<CourseGroupMember> CourseGroupMembers { get; set; } = new List<CourseGroupMember>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<SubscriptionPackage> SubscriptionPackages { get; set; } = new List<SubscriptionPackage>();
}
