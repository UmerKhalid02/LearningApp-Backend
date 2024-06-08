namespace LearningApp.Application.DataTransferObjects.TopicDTO
{
    public class TopicResponseDTO
    {
        public Guid TopicId { get; set; }
        public string? TopicName { get; set; }
        public List<LessonDTO> Lessons { get; set; }
    }

    public class LessonDTO
    {
        public Guid LessonId { get; set; }
        public int LessonNumber { get; set; }
        public string? LessonName { get; set; }
        public bool IsCompleted { get; set; }
    }
}
