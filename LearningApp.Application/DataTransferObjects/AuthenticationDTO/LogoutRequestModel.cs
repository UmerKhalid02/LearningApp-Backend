namespace LearningApp.Application.DataTransferObjects.AuthenticationDTO
{
    public class LogoutRequestModel
    {
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}
