using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class CourseGroupMember
{
    public long Id { get; set; }

    public long CourseGroupId { get; set; }

    public long UserId { get; set; }

    public string RoleInGroup { get; set; } = null!;

    public long? AssignedBy { get; set; }

    public DateTimeOffset AssignedAt { get; set; }

    public virtual User? AssignedByNavigation { get; set; }

    public virtual CourseGroup CourseGroup { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
