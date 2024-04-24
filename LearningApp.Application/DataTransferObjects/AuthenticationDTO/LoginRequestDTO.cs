using System.ComponentModel.DataAnnotations;

namespace LearningApp.Application.DataTransferObjects.AuthenticationDTO
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "Please enter username or email")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string? Password { get; set; }
    }
}
