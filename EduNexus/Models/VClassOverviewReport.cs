using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class VClassOverviewReport
{
    public long ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public int? TotalStudents { get; set; }

    public int? InactiveStudents { get; set; }

    public decimal? AvgProgress { get; set; }
}
