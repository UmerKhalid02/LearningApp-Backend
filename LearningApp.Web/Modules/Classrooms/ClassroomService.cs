using AutoMapper;
using LearningApp.Application.DataTransferObjects.ClassroomDTO;
using LearningApp.Application.Enums;
using LearningApp.Application.Wrappers;
using LearningApp.Data.Entities.ClassroomEntity;
using LearningApp.Data.IRepositories.IClassroomRepository;
using LearningApp.Data.IRepositories.IUserRepository;

namespace LearningApp.Web.Modules.Classrooms
{
    public class ClassroomService : IClassroomService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClassroomRepository _classroomRepository;
        private readonly IMapper _mapper;
        public ClassroomService(IUserRepository userRepository, IClassroomRepository classroomRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _classroomRepository = classroomRepository;
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

        public async Task<Response<ClassroomResponseDTO>> AddClassroom(Guid userId, AddClassroomRequestDTO request)
        {
            var classroom = _mapper.Map<Classroom>(request);

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
    }
}
