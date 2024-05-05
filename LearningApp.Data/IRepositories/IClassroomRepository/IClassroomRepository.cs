﻿using LearningApp.Data.Entities.ClassroomEntity;

namespace LearningApp.Data.IRepositories.IClassroomRepository
{
    public interface IClassroomRepository
    {
        Task<List<Classroom>> GetAllClassrooms();
        Task<Classroom> GetClassroomById(Guid classroomId);
        Task<Classroom> AddClassroom(Classroom classroom);
        Task SaveChangesAsync();
    }
}
