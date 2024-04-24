using LearningApp.Data.Entities.UserEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningApp.Data.Entities
{
    [Table("UserLoginTime")]
    public class UserLoginTime
    {
        [Column("ID")]
        public Guid Id { get; set; }

        [ForeignKey("UserId")]
        [Column("UserID")]
        public virtual Guid UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime? LoginAt { get; set; }
    }
}
