using System.Collections.Generic;
using EduNexus.Models;

namespace EduNexus.Services;

public interface IQuizAttemptService
{
    List<QuizAttempt> GetHistoryForStudent(long studentId);
}
