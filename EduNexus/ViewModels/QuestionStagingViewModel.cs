using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduNexus.Models;

namespace EduNexus.ViewModels;

public class GenerateQuestionsRequest
{
    [Required(ErrorMessage = "Vui lòng ch?n Module")]
    public long ModuleId { get; set; }

    [Required(ErrorMessage = "Vui lòng nh?p ch? d?")]
    [StringLength(300, ErrorMessage = "Ch? d? không quá 300 ký t?")]
    public string Topic { get; set; } = "";

    [Required]
    public string Difficulty { get; set; } = "MEDIUM";

    [Range(1, 20, ErrorMessage = "S? câu t? 1 d?n 20")]
    public int Count { get; set; } = 5;
}

public class QuestionStagingViewModel
{
    public List<Question> StagedQuestions { get; set; } = new();
    public List<EduNexus.Models.Module> Modules { get; set; } = new();
    public GenerateQuestionsRequest Form { get; set; } = new();
    public string? SuccessMessage { get; set; }
    public string? ErrorMessage { get; set; }
    public int LastTokensUsed { get; set; }
}
