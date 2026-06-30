using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class VRevenueReport
{
    public long CourseGroupId { get; set; }

    public string CourseGroupName { get; set; } = null!;

    public DateOnly? Period { get; set; }

    public int? PaymentCount { get; set; }

    public decimal? TotalRevenue { get; set; }
}
