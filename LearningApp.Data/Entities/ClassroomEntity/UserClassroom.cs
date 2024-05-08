using LearningApp.Data.Entities.UserEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningApp.Data.Entities.ClassroomEntity
{
    [Table("UserClassroom")]
    public class UserClassroom : BaseEntity
    {
        [Key]
        [Column("UserClassroomID")]
        public Guid UserClassroomId { get; set; }

        [Required]
        [Column("UserID")]
        [ForeignKey("UserId")]
        public virtual Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [Column("ClassroomID")]
        [ForeignKey("ClassroomId")]
        public virtual Guid ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}
