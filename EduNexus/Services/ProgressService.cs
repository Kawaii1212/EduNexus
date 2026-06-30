using System.Collections.Generic;
using EduNexus.Models;
using EduNexus.Repositories;

namespace EduNexus.Services;

public class ProgressService : IProgressService
{
    private readonly IProgressRepository _progressRepository;

    public ProgressService(IProgressRepository progressRepository)
    {
        _progressRepository = progressRepository;
    }

    public IEnumerable<Enrollment> GetEnrollmentsByStudent(long studentId)
    {
        return _progressRepository.GetEnrollmentsByStudent(studentId);
    }

    public IEnumerable<LearningProgress> GetLearningProgressesByStudent(long studentId)
    {
        return _progressRepository.GetLearningProgressesByStudent(studentId);
    }
}
