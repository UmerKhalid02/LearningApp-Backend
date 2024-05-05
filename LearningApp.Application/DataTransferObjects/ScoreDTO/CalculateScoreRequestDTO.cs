namespace LearningApp.Application.DataTransferObjects.ScoreDTO
{
    public class CalculateScoreRequestDTO
    {
        public Guid LessonId { get; set; }
        public int CorrectProblems { get; set; }
    }
}
