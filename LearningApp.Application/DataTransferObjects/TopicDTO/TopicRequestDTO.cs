using System.ComponentModel.DataAnnotations;

namespace LearningApp.Application.DataTransferObjects.TopicDTO
{
    public class TopicRequestDTO
    {
        [Required(ErrorMessage = "Please enter topic name")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Minimum length must be 3")]
        public string? TopicName { get; set; }
    }
}
