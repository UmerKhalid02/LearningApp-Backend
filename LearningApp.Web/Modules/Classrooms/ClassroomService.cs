using AutoMapper;
using LearningApp.Application.DataTransferObjects.ClassroomDTO;
using LearningApp.Application.Enums;
using LearningApp.Application.Exceptions;
using LearningApp.Application.Wrappers;
using LearningApp.Data.Entities.ClassroomEntity;
using LearningApp.Data.IRepositories.IClassroomRepository;
using LearningApp.Data.IRepositories.ITopicRepository;
using LearningApp.Data.IRepositories.IUserRepository;

namespace LearningApp.Web.Modules.Classrooms
{
    public class ClassroomService : IClassroomService
    {
        private const string allowedChars = "abcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly Random Random = new Random();

        private readonly IUserRepository _userRepository;
        private readonly IClassroomRepository _classroomRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;
        public ClassroomService(IUserRepository userRepository, IClassroomRepository classroomRepository, ITopicRepository topicRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _classroomRepository = classroomRepository;
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<ClassroomResponseDTO>>> GetAllClassrooms()
        {
            var classrooms = await _classroomRepository.GetAllClassrooms();
            var response = _mapper.Map<List<ClassroomResponseDTO>>(classrooms);
            return new Response<List<ClassroomResponseDTO>>(true, response, GeneralMessages.RecordFetched);
        }

        public async Task<Response<ClassroomResponseDTO>> GetClassroomById(Guid classroomId)
        {
            var classroom = await _classroomRepository.GetClassroomById(classroomId);

            if(classroom == null) {
                throw new KeyNotFoundException(GeneralMessages.InvalidClassroomId);
            }

            var response = _mapper.Map<ClassroomResponseDTO>(classroom);
            return new Response<ClassroomResponseDTO>(true, response, GeneralMessages.RecordFetched);
        }

        private async Task<string> GenerateUniqueCode()
        {
            string code;
            bool codeUniqueness = false;
            do
            {
                code = GenerateRandomCode();
                codeUniqueness = await IsCodeUnique(code);
            } while (!codeUniqueness);

            return code;
        }

        private string GenerateRandomCode()
        {
            return new string(Enumerable.Repeat(allowedChars, 8)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        private async Task<bool> IsCodeUnique(string code)
        {
            // check if the generated code is already in use by some other classroom
            if (await _classroomRepository.GetClassroomByCode(code) != null) {
                return false;
            }
            return true;
        }

        public async Task<Response<ClassroomResponseDTO>> AddClassroom(Guid userId, AddClassroomRequestDTO request)
        {
            var classroom = _mapper.Map<Classroom>(request);

            classroom.ClassroomCode = await GenerateUniqueCode();
            classroom.IsActive = true;
            classroom.CreatedAt = DateTime.UtcNow;
            classroom.CreatedBy = userId;

            await _classroomRepository.AddClassroom(classroom);
            await _classroomRepository.SaveChangesAsync();

            return new Response<ClassroomResponseDTO>(true, null, GeneralMessages.RecordAdded);
        }

        public async Task<Response<ClassroomResponseDTO>> UpdateClassroom(Guid userId, Guid classroomId, AddClassroomRequestDTO request)
        {
            var classroom = await _classroomRepository.GetClassroomById(classroomId);

            if (classroom == null) {
                throw new KeyNotFoundException(GeneralMessages.InvalidClassroomId);
            }

            _mapper.Map(request, classroom);
            classroom.UpdatedAt = DateTime.UtcNow;
            classroom.UpdatedBy = userId;

            await _classroomRepository.SaveChangesAsync();
            var response = _mapper.Map<ClassroomResponseDTO>(classroom);

            return new Response<ClassroomResponseDTO>(true, response, GeneralMessages.RecordUpdated);

        }

        public async Task<Response<bool>> DeleteClassroom(Guid userId, Guid classroomId)
        {
            var classroom = await _classroomRepository.GetClassroomById(classroomId);

            if (classroom == null) {
                throw new KeyNotFoundException(GeneralMessages.InvalidClassroomId);
            }

            classroom.UpdatedAt = DateTime.UtcNow;
            classroom.UpdatedBy = userId;
            classroom.DeletedAt = DateTime.UtcNow;
            classroom.DeletedBy = userId;
            classroom.IsActive = false;

            await _classroomRepository.SaveChangesAsync();
            return new Response<bool>(true, true, GeneralMessages.RecordDeleted);
        }

        public async Task<Response<List<ClassroomResponseDTO>>> GetAllUserClassrooms(Guid userId, string userRole)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null) {
                throw new UnauthorizedAccessException(GeneralMessages.UnauthorizedAccess);
            }

            List<Classroom>? classrooms = new List<Classroom>();

            // if the user is a student
            if (userRole == "ST") {
                classrooms = await _classroomRepository.GetAllStudentClassrooms(userId);
            }

            // if the user is either a teacher or admin
            else {
                classrooms = await _classroomRepository.GetAllTeacherClassrooms(userId);
            }

            var response = _mapper.Map<List<ClassroomResponseDTO>>(classrooms);
            return new Response<List<ClassroomResponseDTO>>(true, response, GeneralMessages.RecordFetched);
        }

        public async Task<Response<bool>> AddTopicInClassroom(Guid userId, Guid classroomId, Guid topicId)
        {
            // check if classroom exist for that user
            var classroom = await _classroomRepository.GetTeacherClassroomById(userId, classroomId);
            if (classroom == null) {
                throw new KeyNotFoundException(GeneralMessages.InvalidClassroomId);
            }

            // check if topic exists or not
            var topic = await _topicRepository.GetTeacherTopicById(userId, topicId);
            if (topic == null) {
                throw new KeyNotFoundException(GeneralMessages.InvalidTopicId);
            }

            //classroom.Topics.Add(topic);
            topic.ClassroomId = classroom.ClassroomId;
            topic.Classroom = classroom;
            await _topicRepository.SaveChanges();

            return new Response<bool>(true, true, GeneralMessages.TopicAddedInClassroom);
        }

        public async Task<Response<bool>> JoinClassroom(Guid userId, string userRole, JoinClassroomRequestDTO request)
        {
            if (userRole != "ST") {
                throw new UnauthorizedAccessException(GeneralMessages.OnlyStudentsCanJoinClassroom);
            }

            var classroom = await _classroomRepository.GetClassroomByCode(request.ClassroomCode);
            if (classroom == null) {
                throw new BadRequestException(GeneralMessages.InvalidClassroomCode);
            }

            // check if user is already in the classroom or not
            var userClassroom = await _classroomRepository.CheckStudentInClassroom(userId, classroom.ClassroomId);
            if (userClassroom != null) {
                throw new BadRequestException(GeneralMessages.UserAlreadyEnrolled);
            }

            userClassroom = new UserClassroom()
            {
                UserId = userId,
                ClassroomId = classroom.ClassroomId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = userId
            };
            await _classroomRepository.AddUserInClassroom(userClassroom);
            await _classroomRepository.SaveChangesAsync();

            return new Response<bool>(true, true, GeneralMessages.UserEnrolled);
        }
    }
}
