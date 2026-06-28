using System;

namespace DataAccessLayer.Services;

public interface ISubmissionService
{
    /// <summary>
    /// Submits an essay for a specific assignment and student.
    /// Handles both new submissions and resubmissions.
    /// </summary>
    void SubmitEssay(long assignmentId, long studentId, string content, string? fileUrl);
}
