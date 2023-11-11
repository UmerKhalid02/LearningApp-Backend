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
        [Required]
        public string? Solution { get; set; }

        [Column("TopicID")]
        [ForeignKey("TopicId")]
        [Required]
        public virtual Guid TopicId { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ICollection<Choice>? Choices { get; set; }
    }
}
