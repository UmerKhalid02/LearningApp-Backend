using System.ComponentModel.DataAnnotations;

namespace LearningApp.Application.DataTransferObjects.ScoreDTO
{
    public class CalculateScoreRequestDTO
    {
        [Required(ErrorMessage = "Please specify the lesson id")]
        public Guid LessonId { get; set; }
        [Required(ErrorMessage = "Please specify the number of correct problems")]
        public int CorrectProblems { get; set; }
        [Required(ErrorMessage = "Please specify the user performance")]
        public int Performance { get; set; }
    }
}
