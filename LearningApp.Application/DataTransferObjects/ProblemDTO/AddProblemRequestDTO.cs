using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LearningApp.Application.DataTransferObjects.ProblemDTO
{
    public class AddProblemRequestDTO
    {
        [Required]
        public Guid LessonId { get; set; }
        [Required]
        public string? Description { get; set; }
        [AllowNull]
        public string? SampleCode { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Difficulty { get; set; }
        [Required]
        public string? Solution { get; set; }
        public List<ChoiceRequestDTO>? Choices { get; set; }
    }

    public class ChoiceRequestDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Minimum length for ChoiceText must be 1")]
        public string? ChoiceText { get; set; }
    }
}
