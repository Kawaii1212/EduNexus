using System.Collections.Generic;
using EduNexus.Models;

namespace EduNexus.Services;

public interface IProgressService
{
    IEnumerable<Enrollment> GetEnrollmentsByStudent(long studentId);
    IEnumerable<LearningProgress> GetLearningProgressesByStudent(long studentId);
}
