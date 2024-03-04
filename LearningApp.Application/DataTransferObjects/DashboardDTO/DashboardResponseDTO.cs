using System.ComponentModel.DataAnnotations;

namespace LearningApp.Application.DataTransferObjects.DashboardDTO
{
    public class DashboardResponseDTO
    {
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int? XP { get; set; }
        public double Multiplier { get; set; }
        public int Level { get; set; }
    }
}
