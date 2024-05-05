﻿using LearningApp.Data.Entities.ClassroomEntity;
using LearningApp.Data.IRepositories.IClassroomRepository;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data.Repositories.ClassroomRepository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly EFDataContext _context;
        public ClassroomRepository(EFDataContext context)
        {
            _context = context;
        }

        public Task<List<Classroom>> GetAllClassrooms()
        {
            var classrooms = _context.Classrooms
                .Include(x => x.UserClassrooms).ThenInclude(u => u.User)
                .Where(x => x.IsActive)
                .ToListAsync();

            return classrooms;
        }

        public async Task<Classroom> GetClassroomById(Guid classroomId)
        {
            var classroom = await _context.Classrooms
                .Include(x => x.UserClassrooms).ThenInclude(u => u.User)
                .FirstOrDefaultAsync(x => x.ClassroomId == classroomId && x.IsActive);

            return classroom;
        }

        public async Task<Classroom> AddClassroom(Classroom classroom)
        {
            await _context.Classrooms.AddAsync(classroom);
            return classroom;
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
