using LearningApp.Data.Entities.ClassroomEntity;

namespace LearningApp.Data.IRepositories.IClassroomRepository
{
    public interface IClassroomRepository
    {
        Task<List<Classroom>> GetAllClassrooms();
        Task<Classroom> GetClassroomById(Guid classroomId);
        Task<Classroom?> GetTeacherClassroomById(Guid userId, Guid classroomId);
        Task<Classroom> AddClassroom(Classroom classroom);
        Task SaveChangesAsync();
        Task<List<Classroom>> GetAllStudentClassrooms(Guid userId);
        Task<List<Classroom>> GetAllTeacherClassrooms(Guid userId);
        Task<Classroom?> GetClassroomByCode(string code);
        Task<UserClassroom?> CheckStudentInClassroom(Guid studentId, Guid classroomId);
        Task<UserClassroom> AddUserInClassroom(UserClassroom userClassroom);
    }
}
