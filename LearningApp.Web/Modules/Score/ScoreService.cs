using LearningApp.Application.DataTransferObjects.ScoreDTO;
using LearningApp.Application.Enums;
using LearningApp.Application.Wrappers;
using LearningApp.Data.Entities.ProblemEntity;
using LearningApp.Data.Entities.UserEntity;
using LearningApp.Data.IRepositories.IDashboardRepository;
using LearningApp.Data.IRepositories.ILessonRepository;
using LearningApp.Data.IRepositories.IUserProgressRepository;

namespace LearningApp.Web.Modules.Score
{
    public class ScoreService : IScoreService
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IUserProgressRepository _userProgressRepository;
        public ScoreService(IDashboardRepository dashboardRepository, ILessonRepository lessonRepository, IUserProgressRepository userProgressRepository)
        {
            _dashboardRepository = dashboardRepository;
            _lessonRepository = lessonRepository;
            _userProgressRepository = userProgressRepository;
        }

        private async Task<bool> IsTopicCompleted(Guid userId, Lesson lesson)
        {
            // get lessons count from the topics
            int totalLessons = lesson.Topic.Lessons.Count;
            int completedLessons = await _userProgressRepository.CompletedLessonsCount(userId, lesson.TopicId);

            if(totalLessons == completedLessons)
                return true;

            return false;
        }

        public async Task<Response<CalculateScoreResponseDTO>> CalculateScore(Guid userId, CalculateScoreRequestDTO request)
        {
            int xpGained = 0;

            // check if lessonId is correct
            var lesson = await _lessonRepository.GetLessonById(request.LessonId);
            if (lesson == null)
                throw new KeyNotFoundException(GeneralMessages.InvalidLessonId);

            var user = await _dashboardRepository.GetUserDetails(userId);
            if (user == null)
                throw new UnauthorizedAccessException(GeneralMessages.UnauthorizedAccess);

            // update user performance
            user.Performance = request.Performance;
            await _dashboardRepository.SaveChangesAsync();

            // check if user progress exists for the current lesson
            var progress = await _userProgressRepository.GetUserProgressForALesson(userId, lesson.LessonId);
            if (progress == null)
            {
                xpGained = (int)Math.Round(request.CorrectProblems * user.Multiplier);

                var totalUserScore = user.XP + xpGained;
                user.TotalXP += xpGained;

                var dif = totalUserScore / 1000.000;

                if (dif > 1)
                {
                    user.Level += 1;
                    user.XP = totalUserScore - 1000;
                }

                else
                {
                    user.XP += xpGained;
                }

                // make an entry in user progress table
                UserProgress userProgress = new UserProgress()
                {
                    UserId = userId,
                    LessonId = lesson.LessonId,
                    TopicId = lesson.TopicId,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                };
                await _userProgressRepository.AddUserProgress(userProgress);
                await _dashboardRepository.SaveChangesAsync();

                // check if the topic is completed
                bool isTopicCompleted =  await IsTopicCompleted(userId, lesson);
                if (isTopicCompleted) {
                    UserProgress topicCompleted = new UserProgress()
                    {
                        UserId = userId,
                        TopicId = lesson.TopicId,
                        TopicCompleted = true,
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true,
                    };
                    await _userProgressRepository.AddUserProgress(topicCompleted);
                    await _dashboardRepository.SaveChangesAsync();
                }
            }

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
