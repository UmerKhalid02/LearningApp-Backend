using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LearningApp.Data.Entities.ProblemEntity
{
    [Table("Problem")]
    public class Problem : BaseEntity
    {
        [Key]
        [Column("ProblemID")]
        public Guid ProblemId { get; set; }
        [Required]
        public string? Description { get; set; }
        [AllowNull]
        public string? SampleCode { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Difficulty { get; set; }

        [Column("LessonID")]
        [ForeignKey("LessonId")]
        [Required]
        public Guid LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public virtual ICollection<Solution> Solution { get; set; }
        public virtual ICollection<Choice>? Choices { get; set; }
    }
}
