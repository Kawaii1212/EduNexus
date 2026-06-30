using System.Collections.Generic;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories;

public interface IQuizAttemptRepository
{
    List<QuizAttempt> GetByStudentId(long studentId);
}
