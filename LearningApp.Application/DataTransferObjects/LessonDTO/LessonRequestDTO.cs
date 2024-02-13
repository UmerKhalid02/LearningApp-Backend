using System.ComponentModel.DataAnnotations;

namespace LearningApp.Application.DataTransferObjects.LessonDTO
{
    public class LessonRequestDTO
    {
        [Required]
        public Guid TopicId { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Lesson Number must be >= 1 and <= 1000")]
        public int LessonNumber { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Lesson name must contain atleast 3 characters")]
        public string? LessonName { get; set; }
    }
}
