using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories;

public interface ISubmissionRepository
{
    void AddSubmission(Submission submission);
    void UpdateSubmission(Submission submission);
    Submission? GetSubmissionByAssignmentAndStudent(long assignmentId, long studentId);
    Submission? GetSubmissionById(long submissionId);
    List<Submission> GetAllSubmissions();
}
