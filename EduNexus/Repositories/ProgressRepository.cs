using System.Collections.Generic;
using EduNexus.DAOs;
using EduNexus.Models;

namespace EduNexus.Repositories;

public class ProgressRepository : IProgressRepository
{
    public IEnumerable<Enrollment> GetEnrollmentsByStudent(long studentId)
    {
        return ProgressDAO.Instance.GetEnrollmentsByStudent(studentId);
    }

    public IEnumerable<LearningProgress> GetLearningProgressesByStudent(long studentId)
    {
        return ProgressDAO.Instance.GetLearningProgressesByStudent(studentId);
    }
}
