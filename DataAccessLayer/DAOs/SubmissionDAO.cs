using System.Linq;
using DataAccessLayer.Models;

namespace DataAccessLayer.DAOs;

public class SubmissionDAO : BaseDAO<Submission>
{
    private static SubmissionDAO? instance = null;
    private static readonly object instanceLock = new object();

    private SubmissionDAO() { }

    public static new SubmissionDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new SubmissionDAO();
                }
                return instance;
            }
        }
    }

    public Submission? GetByAssignmentAndStudent(long assignmentId, long studentId)
    {
        using var context = GetContext();
        return context.Submissions
            .FirstOrDefault(s => s.AssignmentId == assignmentId && s.StudentId == studentId);
    }
}
