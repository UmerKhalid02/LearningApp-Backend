using LearningApp.Data.Entities.UserEntity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearningApp.Data.Entities
{
    [Table("UserLogin")]
    public class UserLogin
    {
        [Key]
        [Column("UserLoginID")]
        public Guid UserLoginId { get; set; }
        public virtual Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public string RefreshToken { get; set; }
        public string Status { get; set; }
        public DateTime RefreshTokenCreatedAt { get; set; }
        public DateTime RefreshTokenUpdatedAt { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public DateTime? LoginAt { get; set; }
        public DateTime? LogOutAt { get; set; }
    }
}
