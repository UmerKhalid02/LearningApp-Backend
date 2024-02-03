using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningApp.Data.Entities.ProblemEntity
{
    [Table("Lesson")]
    public class Lesson: BaseEntity
    {
        [Key]
        [Column("LessonID")]
        public Guid LessonId { get; set; }

        [Required]
        public int LessonNumber { get; set; }

        [Required]
        public string? LessonName { get; set; }

        [Column("TopicID")]
        [ForeignKey("TopicId")]
        [Required]
        public virtual Guid TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        public virtual ICollection<Problem>? Problems { get; set; }
    }
}
