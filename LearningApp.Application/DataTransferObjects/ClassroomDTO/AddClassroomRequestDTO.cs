using System.ComponentModel.DataAnnotations;

namespace LearningApp.Application.DataTransferObjects.ClassroomDTO
{
    public class AddClassroomRequestDTO
    {
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Classroom name should be atleast 3 character long")]
        [Required(ErrorMessage = "Please enter classroom name")]
        public string? ClassroomName { get; set; }
        public string? ClassroomDescription { get; set; }
    }
}
