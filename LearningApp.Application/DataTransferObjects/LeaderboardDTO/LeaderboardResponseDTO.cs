namespace LearningApp.Application.DataTransferObjects.LeaderboardDTO
{
    public class LeaderboardResponseDTO
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public int? XP { get; set; }
    }
}
