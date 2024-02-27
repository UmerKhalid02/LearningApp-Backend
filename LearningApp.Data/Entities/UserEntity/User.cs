using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningApp.Data.Entities.UserEntity
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Key]
        [Column("UserID")]
        public Guid UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public int? XP { get; set; }
        [DefaultValue(1)]
        public double Multiplier { get; set; } = 1;

        [Required]
        public virtual UserRole? UserRole { get; set; }
    }
}
