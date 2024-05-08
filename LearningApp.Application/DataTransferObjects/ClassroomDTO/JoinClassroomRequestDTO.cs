using System.ComponentModel.DataAnnotations;

namespace LearningApp.Application.DataTransferObjects.ClassroomDTO
{
    public class JoinClassroomRequestDTO
    {
        [Required(ErrorMessage = "Please enter classroom code to join")]
        public string ClassroomCode { get; set; }
    }
}
