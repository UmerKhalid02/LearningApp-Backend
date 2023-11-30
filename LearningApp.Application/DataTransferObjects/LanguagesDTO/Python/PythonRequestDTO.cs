using System.ComponentModel.DataAnnotations;

namespace LearningApp.Application.DataTransferObjects.LanguagesDTO.Python
{
    public class PythonRequestDTO
    {
        [Required(ErrorMessage = "Please input code")]
        public string? code { get; set; }
    }
}
