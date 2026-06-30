using System.Collections.Generic;
using EduNexus.Models;

namespace EduNexus.Repositories;

public interface IProgressRepository
{
    IEnumerable<Enrollment> GetEnrollmentsByStudent(long studentId);
    IEnumerable<LearningProgress> GetLearningProgressesByStudent(long studentId);
}
