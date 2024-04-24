using LearningApp.Application.DataTransferObjects.ProblemDTO;

namespace LearningApp.Application.DataTransferObjects.LessonDTO
{
    public class LessonResponseDTO
    {
        public Guid LessonId { get; set; }
        public int LessonNumber { get; set; }
        public string? LessonName { get; set; }
        public LessonTopicDTO Topic { get; set; }
        public List<LessonProblemsDTO> Problems { get; set; }
    }

    public class LessonTopicDTO
    {
        public Guid TopicId { get; set; }
        public string? TopicName { get; set; }
    }

    public class LessonProblemsDTO
    {
        public Guid ProblemId { get; set; }
        public string? Description { get; set; }
        public string? SampleCode { get; set; }
        public string? Type { get; set; }
        public string? Difficulty { get; set; }
        public string? Solution { get; set; }
        public List<ChoiceDTO>? Choices { get; set; }
    }
}
