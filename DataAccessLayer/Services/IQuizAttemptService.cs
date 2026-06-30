using System.Collections.Generic;
using DataAccessLayer.Models;

namespace DataAccessLayer.Services;

public interface IQuizAttemptService
{
    List<QuizAttempt> GetHistoryForStudent(long studentId);
}
