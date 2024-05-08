﻿using LearningApp.Application.DataTransferObjects.ClassroomDTO;
using LearningApp.Application.Wrappers;

namespace LearningApp.Web.Modules.Classrooms
{
    public interface IClassroomService
    {
        Task<Response<List<ClassroomResponseDTO>>> GetAllClassrooms();
        Task<Response<ClassroomResponseDTO>> GetClassroomById(Guid classroomId);
        Task<Response<ClassroomResponseDTO>> AddClassroom(Guid userId, AddClassroomRequestDTO requestDTO);
        Task<Response<ClassroomResponseDTO>> UpdateClassroom(Guid userId, Guid classroomId, AddClassroomRequestDTO requestDTO);
        Task<Response<bool>> DeleteClassroom(Guid userId, Guid classroomId);
        Task<Response<List<ClassroomResponseDTO>>> GetAllUserClassrooms(Guid userId, string userRole);
        Task<Response<bool>> AddTopicInClassroom(Guid userId, Guid classroomId, Guid topicId);
        Task<Response<bool>> JoinClassroom(Guid userId, string userRole, JoinClassroomRequestDTO request);
    }
}
