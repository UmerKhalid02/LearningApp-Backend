using System.ComponentModel.DataAnnotations;

namespace LearningApp.Application.DataTransferObjects.AuthenticationDTO
{
    public class RegisterRequestDTO
    {
        [Required(ErrorMessage = "Please enter username")]
        [RegularExpression("^[a-zA-Z0-9_.-]{3,16}$", ErrorMessage = "Invalid username")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "Please enter password")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long and at most 15 characters long")]
        public string? Password { get; set; }
        
        [Required(ErrorMessage = "Please enter confirm password")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select role")]
        public string? Role { get; set; }
    }
}
