using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningApp.Data.Entities.ClassroomEntity
{
    [Table("Classroom")]
    public class Classroom : BaseEntity
    {
        [Key]
        [Column("ClassroomID")]
        public Guid ClassroomId { get; set; }

        [Required]
        public string? ClassroomName { get; set; }

        public ICollection<UserClassroom> UserClassrooms { get; set; }
    }
}
