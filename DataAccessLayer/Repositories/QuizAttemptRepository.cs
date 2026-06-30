using System.Collections.Generic;
using DataAccessLayer.DAOs;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories;

public class QuizAttemptRepository : IQuizAttemptRepository
{
    public List<QuizAttempt> GetByStudentId(long studentId)
    {
        return QuizAttemptDAO.Instance.GetByStudentIdWithDetails(studentId);
    }
}
