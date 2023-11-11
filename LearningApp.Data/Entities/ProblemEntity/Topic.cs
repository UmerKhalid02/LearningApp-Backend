using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
