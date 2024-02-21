using AutoMapper;
using LearningApp.Application.DataTransferObjects.LeaderboardDTO;
using LearningApp.Application.Enums;
using LearningApp.Application.Wrappers;
using LearningApp.Data.IRepositories.ILeaderboardRepository;

namespace LearningApp.Web.Modules.Leaderboard
{
    public class LeaderboardService : ILeaderboardService
    {
        private readonly ILeaderboardRepository _leaderboardRepository;
        private readonly IMapper _mapper;
        public LeaderboardService(ILeaderboardRepository leaderboardRepository, IMapper mapper)
        {
            _leaderboardRepository = leaderboardRepository;
            _mapper = mapper;
        }
        public async Task<Response<List<LeaderboardResponseDTO>>> GetLeaderboard()
        {
            var users = await _leaderboardRepository.GetLeaderboardStudentsTop100();
            var response = _mapper.Map<List<LeaderboardResponseDTO>>(users);
            return new Response<List<LeaderboardResponseDTO>>(true, response, GeneralMessages.RecordFetched);
        }
    }
}
