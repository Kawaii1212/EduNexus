using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace DataAccessLayer.DAOs;

public class QuizAttemptDAO : BaseDAO<QuizAttempt>
{
    private static QuizAttemptDAO? instance = null;
    private static readonly object instanceLock = new object();

    private QuizAttemptDAO() { }

    public static new QuizAttemptDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new QuizAttemptDAO();
                }
                return instance;
            }
        }
    }

    public List<QuizAttempt> GetByStudentIdWithDetails(long studentId)
    {
        using var context = GetContext();
        return context.QuizAttempts
            .Include(qa => qa.Quiz)
            .ThenInclude(q => q.Course)
            .Where(qa => qa.StudentId == studentId)
            .OrderByDescending(qa => qa.StartTime)
            .ToList();
    }
}
