using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LearningApp.Data.Entities.AuthenticationEntity;

namespace LearningApp.Data.Entities.UserEntity
{
    [Table("UserRole")]
    public class UserRole : BaseEntity
    {
        [Key]
        [Column("UserRoleID")]
        public Guid UserRoleId { get; set; }

        [Column("UserID")]
        [ForeignKey("UserId")]
        public virtual Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Column("RoleID")]
        [ForeignKey("RoleId")]
        public virtual Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
