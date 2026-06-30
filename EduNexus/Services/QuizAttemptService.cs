using System.Collections.Generic;
using EduNexus.Models;
using EduNexus.Repositories;

namespace EduNexus.Services;

public class QuizAttemptService : IQuizAttemptService
{
    private readonly IQuizAttemptRepository _quizAttemptRepository;

    public QuizAttemptService(IQuizAttemptRepository quizAttemptRepository)
    {
        _quizAttemptRepository = quizAttemptRepository;
    }

    public List<QuizAttempt> GetHistoryForStudent(long studentId)
    {
        return _quizAttemptRepository.GetByStudentId(studentId);
    }
}
