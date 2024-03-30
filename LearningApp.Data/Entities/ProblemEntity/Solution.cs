using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningApp.Data.Entities.ProblemEntity
{
    [Table("Solution")]
    public class Solution
    {
        [Key]
        public Guid SolutionId { get; set; }
        
        [Required]
        [Column("ProblemID")]
        [ForeignKey("ProblemId")]
        public virtual Guid ProblemId { get; set; }

        [Required]
        public string? SolutionText { get; set; }
        public bool IsActive { get; set; }
    }
}
