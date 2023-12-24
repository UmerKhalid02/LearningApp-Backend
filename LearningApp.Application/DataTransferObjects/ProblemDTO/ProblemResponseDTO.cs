
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
        public TopicDTO Topic { get; set; }
        public int LessonNumber { get; set; }
        public List<ChoiceDTO>? Choices { get; set; }
    }

    public class TopicDTO
    {
        public Guid TopicId { get; set; }
        public string? TopicName { get; set; }
    }

    public class ChoiceDTO
    {
        public Guid ChoiceId { get; set; }
        public string? ChoiceText { get; set; }
    }
}
