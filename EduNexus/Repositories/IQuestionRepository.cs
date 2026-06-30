using System.Collections.Generic;
using EduNexus.Models;

namespace EduNexus.Repositories;

public interface IQuestionRepository
{
    List<Question> GetDraftsByModuleId(long moduleId);
    List<Module> GetAllModules();
    void AddRange(List<Question> questions);
    bool Approve(long questionId, long approvedByUserId);
    bool Reject(long questionId);
    bool DeleteDraft(long questionId);
    Question? GetById(long id);
    void Add(Question question);
    void Update(Question question);
    void Delete(Question question);
    List<Question> GetQuestions(long? moduleId, string? difficulty, string? status, string? searchTerm);
}
