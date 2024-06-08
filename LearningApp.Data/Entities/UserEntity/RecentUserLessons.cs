using LearningApp.Data.Entities.ProblemEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningApp.Data.Entities.UserEntity
{
    [Table("RecentUserLessons")]
    public class RecentUserLessons
    {
        [Key]
        public int RecentUserLessonsId { get; set; }

        [Column("UserID")]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Column("LessonID")]
        [ForeignKey("LessonId")]
        public virtual Guid LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public DateTime DateCompleted { get; set; }

        public bool IsActive { get; set; }
    }
}
