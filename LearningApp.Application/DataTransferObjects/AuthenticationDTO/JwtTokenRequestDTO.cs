namespace LearningApp.Application.DataTransferObjects.AuthenticationDTO
{
    public class JwtTokenRequestDTO
    {
        public string? JwtToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
