using LearningApp.Data.Entities.ClassroomEntity;
using LearningApp.Data.Entities.UserEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LearningApp.Data.Entities.ProblemEntity
{
    [Table("Topic")]
    public class Topic : BaseEntity
    {
        [Key]
        [Column("TopicID")]
        public Guid TopicId { get; set; }

        [Required]
        public string? TopicName { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }

        [AllowNull]
        [Column("ClassroomID")]
        [ForeignKey("ClassroomId")]
        public virtual Guid? ClassroomId { get; set; }
        public virtual Classroom? Classroom { get; set; }

        public virtual ICollection<UserProgress> UserProgresses { get; set; }
    }
}
