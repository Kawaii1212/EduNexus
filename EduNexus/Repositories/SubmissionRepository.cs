using EduNexus.DAOs;
using EduNexus.Models;

namespace EduNexus.Repositories;

public class SubmissionRepository : ISubmissionRepository
{
    public void AddSubmission(Submission submission)
    {
        SubmissionDAO.Instance.Add(submission);
    }

    public void UpdateSubmission(Submission submission)
    {
        SubmissionDAO.Instance.Update(submission);
    }

    public Submission? GetSubmissionByAssignmentAndStudent(long assignmentId, long studentId)
    {
        return SubmissionDAO.Instance.GetByAssignmentAndStudent(assignmentId, studentId);
    }

    public Submission? GetSubmissionById(long submissionId)
    {
        return SubmissionDAO.Instance.GetByIdWithDetails(submissionId);
    }

    public List<Submission> GetAllSubmissions()
    {
        return SubmissionDAO.Instance.GetAllWithDetails();
    }
}
