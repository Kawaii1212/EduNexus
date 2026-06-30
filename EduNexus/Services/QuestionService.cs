using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using EduNexus.Models;
using EduNexus.Repositories;

namespace EduNexus.Services;

// ---------------------------------------------
// Interface
// ---------------------------------------------
public interface IQuestionService
{
    Task<(List<Question> Questions, int TokensUsed)> GenerateAndSaveAsync(
        long moduleId, string topic, string difficulty, int count, long requesterId);

    List<Question> GetDraftsByModule(long moduleId);
    List<Module> GetAllModules();
    bool Approve(long questionId, long approvedByUserId);
    bool Reject(long questionId);
    bool DeleteDraft(long questionId);
    Question? GetById(long id);
    void Add(Question question);
    void AddRange(List<Question> questions);
    void Update(Question question);
    void Delete(Question question);
    List<Question> GetQuestions(long? moduleId, string? difficulty, string? status, string? searchTerm);
}

// ---------------------------------------------
// Implementation
// ---------------------------------------------
public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _repo;
    private readonly GeminiService _gemini;

    public QuestionService(IQuestionRepository repo, GeminiService gemini)
    {
        _repo = repo;
        _gemini = gemini;
    }

    public async Task<(List<Question> Questions, int TokensUsed)> GenerateAndSaveAsync(
        long moduleId, string topic, string difficulty, int count, long requesterId)
    {
        var prompt = BuildPrompt(topic, difficulty, count);
        var rawText = await _gemini.GenerateTextAsync(prompt);
        var parsed = ParseResponse(rawText);

        if (parsed.Count == 0)
            throw new Exception("AI không sinh du?c câu h?i. Vui lòng th? l?i v?i ch? d? khác.");

        var questions = new List<Question>();
        foreach (var item in parsed)
        {
            questions.Add(new Question
            {
                ModuleId = moduleId,
                Content = item.Content,
                OptionA = item.OptionA,
                OptionB = item.OptionB,
                OptionC = item.OptionC,
                OptionD = item.OptionD,
                CorrectOption = item.CorrectOption.ToUpper(),
                Difficulty = difficulty.ToUpper(),
                AiExplanation = item.Explanation,
                Source = "AI_GENERATED",
                Status = "DRAFT",
                CreatedBy = requesterId,
                CreatedAt = DateTimeOffset.UtcNow
            });
        }

        _repo.AddRange(questions);
        return (questions, _gemini.EstimateTokens(prompt, rawText));
    }

    public List<Question> GetDraftsByModule(long moduleId)
        => _repo.GetDraftsByModuleId(moduleId);

    public List<Module> GetAllModules()
        => _repo.GetAllModules();

    public bool Approve(long questionId, long approvedByUserId)
        => _repo.Approve(questionId, approvedByUserId);

    public bool Reject(long questionId)
        => _repo.Reject(questionId);

    public bool DeleteDraft(long questionId)
        => _repo.DeleteDraft(questionId);

    public Question? GetById(long id)
        => _repo.GetById(id);

    public void Add(Question question)
        => _repo.Add(question);

    public void AddRange(List<Question> questions)
        => _repo.AddRange(questions);

    public void Update(Question question)
        => _repo.Update(question);

    public void Delete(Question question)
    {
        var q = _repo.GetById(question.Id);
        if (q != null)
        {
            _repo.Delete(q);
        }
    }

    public List<Question> GetQuestions(long? moduleId, string? difficulty, string? status, string? searchTerm)
        => _repo.GetQuestions(moduleId, difficulty, status, searchTerm);

    // -- Helpers ------------------------------

    private static string BuildPrompt(string topic, string difficulty, int count)
    {
        return "B?n là chuyên gia giáo d?c. Hãy sinh " + count + " câu h?i tr?c nghi?m 4 dáp án v?: \"" + topic + "\".\n"
             + "Ð? khó: " + difficulty + ".\n\n"
             + "Ch? tr? v? JSON array thu?n, KHÔNG có markdown, KHÔNG có backtick:\n"
             + "[\n"
             + "  {\n"
             + "    \"content\": \"N?i dung câu h?i?\",\n"
             + "    \"optionA\": \"Ðáp án A\",\n"
             + "    \"optionB\": \"Ðáp án B\",\n"
             + "    \"optionC\": \"Ðáp án C\",\n"
             + "    \"optionD\": \"Ðáp án D\",\n"
             + "    \"correctOption\": \"A\",\n"
             + "    \"explanation\": \"Gi?i thích ng?n g?n.\"\n"
             + "  }\n"
             + "]";
    }

    private static List<GeminiItem> ParseResponse(string raw)
    {
        var text = raw.Trim();
        if (text.StartsWith("```"))
        {
            var start = text.IndexOf('\n') + 1;
            var end = text.LastIndexOf("```");
            if (end > start) text = text[start..end].Trim();
        }
        try
        {
            Console.WriteLine($">>> [QuestionService] Ðang parse JSON ({text.Length} kí t?)...");
            var items = JsonSerializer.Deserialize<List<GeminiItem>>(text,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<GeminiItem>();
            Console.WriteLine($">>> [QuestionService] Parse thành công. S? câu: {items.Count}");
            return items;
        }
        catch (Exception ex)
        {
            Console.WriteLine($">>> [QuestionService] L?I PARSE JSON: {ex.Message}");
            Console.WriteLine($">>> [QuestionService] N?i dung JSON l?i: {text}");
            return new List<GeminiItem>();
        }
    }

    private class GeminiItem
    {
        public string Content { get; set; } = "";
        public string OptionA { get; set; } = "";
        public string OptionB { get; set; } = "";
        public string OptionC { get; set; } = "";
        public string OptionD { get; set; } = "";
        public string CorrectOption { get; set; } = "";
        public string Explanation { get; set; } = "";
    }
}
