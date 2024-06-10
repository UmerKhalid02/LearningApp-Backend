﻿using LearningApp.Application.DataTransferObjects.TopicDTO;

namespace LearningApp.Application.DataTransferObjects.ClassroomDTO
{
    public class ClassroomResponseDTO
    {
        public Guid ClassroomId { get; set; }
        public string? ClassroomName { get; set; }
        public string? ClassroomDescription { get; set; }
        public string? ClassroomCode { get; set; }
        public int TotalStudents { get; set; }
        public List<Student>? Students { get; set;}
        public Guid CreatedBy { get; set; }
        public List<TopicResponseDTO>? Topics { get; set; }
    }

    public class Student
    { 
        public Guid StudentId { get; set; }
        public string? StudentName { get; set;}
    }
}
