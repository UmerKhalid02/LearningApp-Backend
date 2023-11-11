using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningApp.Data.Entities.ProblemEntity
{
    [Table("Choice")]
    public class Choice : BaseEntity
    {
        [Key]
        [Column("ChoiceID")]
        public Guid ChoiceId { get; set; }

        [ForeignKey("ProblemId")]
        [Column("ProblemID")]
        public Guid ProblemId { get; set;}

        [Required]
        public string? ChoiceText { get; set; }
    }
}
