using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class Class
{
    public long Id { get; set; }

    public long CourseId { get; set; }

    public long? TeacherId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int Capacity { get; set; }

    public decimal Price { get; set; }

    public string Status { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<ClassMaterial> ClassMaterials { get; set; } = new List<ClassMaterial>();

    public virtual Course Course { get; set; } = null!;

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<LearningProgress> LearningProgresses { get; set; } = new List<LearningProgress>();

    public virtual User? Teacher { get; set; }
}
