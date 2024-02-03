
namespace LearningApp.Application.DataTransferObjects.ProblemDTO
{
    public class ProblemResponseDTO
    {
        public Guid ProblemId { get; set; }
        public string? Description { get; set; }
        public string? SampleCode { get; set; }
        public string? Type { get; set; }
        public string? Difficulty { get; set; }
        public string? Solution { get; set; }
        public List<ChoiceDTO>? Choices { get; set; }
        public LessonDTO Lesson { get; set; }
    }

    public class LessonDTO
    {
        public Guid LessonId { get; set; }
        public int LessonNumber { get; set; }
        public string? LessonName { get; set; }
    }

    public class ChoiceDTO
    {
        public Guid ChoiceId { get; set; }
        public string? ChoiceText { get; set; }
    }
}
