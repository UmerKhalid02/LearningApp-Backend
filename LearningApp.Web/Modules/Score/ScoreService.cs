using LearningApp.Application.DataTransferObjects.ScoreDTO;
using LearningApp.Application.Enums;
using LearningApp.Application.Wrappers;
using LearningApp.Data.IRepositories.IDashboardRepository;

namespace LearningApp.Web.Modules.Score
{
    public class ScoreService : IScoreService
    {
        private readonly IDashboardRepository _dashboardRepository;
        public ScoreService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<Response<CalculateScoreResponseDTO>> CalculateScore(Guid userId, CalculateScoreRequestDTO request)
        {
            var user = await _dashboardRepository.GetUserDetails(userId);
            if (user == null)
                throw new UnauthorizedAccessException(GeneralMessages.UnauthorizedAccess);

            int xpGained = (int)Math.Round(request.CorrectProblems * user.Multiplier);

            var totalUserScore = user.XP + xpGained;
            user.TotalXP += xpGained;

            var dif = totalUserScore / 1000.000;

            if (dif > 1) {
                user.Level += 1;
                user.XP = totalUserScore - 1000;
            }

            else {
                user.XP += xpGained;
            }

            await _dashboardRepository.SaveChangesAsync();

            CalculateScoreResponseDTO response = new()
            {
                XpGained = xpGained,
                Xp = user.XP,
                TotalXp = user.TotalXP,
                Level = user.Level,
            };

            return new Response<CalculateScoreResponseDTO>(true, response, "Updated Score");
        }
    }
}
