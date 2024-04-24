using LearningApp.Application.DataTransferObjects.ScoreDTO;
using LearningApp.Application.Wrappers;

namespace LearningApp.Web.Modules.Score
{
    public interface IScoreService
    {
        Task<Response<CalculateScoreResponseDTO>> CalculateScore(Guid userId, CalculateScoreRequestDTO request);
    }
}
