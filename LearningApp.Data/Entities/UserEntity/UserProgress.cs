using LearningApp.Data.Entities.ProblemEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningApp.Data.Entities.UserEntity
{
    // stores information about completed lessons of a specific user
    [Table("UserProgress")]
    public class UserProgress : BaseEntity
    {
        [Key]
        [ForeignKey("UserId")]
        public Guid UserProgressId { get; set; }
        
        [Column("UserID")]
        [ForeignKey("UserId")]
        public virtual Guid UserId { get; set; }

        [Column("LessonID")]
        [ForeignKey("LessonId")]
        public virtual Guid? LessonId { get; set; }
        public virtual Lesson? Lesson { get; set; }

        [Column("TopicID")]
        public virtual Guid TopicId { get; set; }

        public bool TopicCompleted { get; set; }
    }
}
