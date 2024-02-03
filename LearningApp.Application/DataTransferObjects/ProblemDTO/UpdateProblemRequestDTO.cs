using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LearningApp.Application.DataTransferObjects.ProblemDTO
{
    public class UpdateProblemRequestDTO
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
        public List<UpdateChoiceRequestDTO>? Choices { get; set; }
    }

    public class UpdateChoiceRequestDTO
    {
        public Guid? ChoiceId { get; set;}
        [Required]
        [MinLength(1, ErrorMessage = "Minimum length for ChoiceText must be 1")]
        public string? ChoiceText { get; set; }
    }
}
