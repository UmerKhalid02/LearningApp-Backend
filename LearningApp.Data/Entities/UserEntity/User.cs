using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningApp.Data.Entities.UserEntity
{
    [Table("User")]
    public class User: BaseEntity
    {
        [Key]
        [Column("UserID")]
        public Guid UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public virtual UserRole? UserRole { get; set; }
    }
}
