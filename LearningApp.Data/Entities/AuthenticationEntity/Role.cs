using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearningApp.Data.Entities.AuthenticationEntity
{
    public class Role : BaseEntity
    {
        [Key]
        [Column("RoleID")]
        public Guid RoleId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? RoleName { get; set; }

        [DataType(DataType.Text)]
        public string? Description { get; set; }
    }
}
