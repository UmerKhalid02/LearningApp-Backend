using System.ComponentModel.DataAnnotations;

namespace LearningApp.Application.DataTransferObjects.DashboardDTO
{
    public class DashboardResponseDTO
    {
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int? XP { get; set; }
        public double Multiplier { get; set; }
        public int Level { get; set; }
        public int Performance { get; set; }
        public string? Role { get; set; }
        public List<RecentLessonsDTO>? recentLessons { get; set; }
    }

    public class  RecentLessonsDTO
    {
        public Guid LessonId { get; set; }
        public int LessonNumber { get; set; }
        public string? LessonName { get; set; }
    }
}
