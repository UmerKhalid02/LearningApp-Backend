namespace LearningApp.Application.DataTransferObjects.ClassroomDTO
{
    public class ClassroomResponseDTO
    {
        public Guid ClassroomId { get; set; }
        public string ClassroomName { get; set; }
        public int TotalStudents { get; set; }
        public List<Student> Students { get; set;}
    }

    public class Student
    { 
        public Guid StudentId { get; set; }
        public string StudentName { get; set;}
    }
}
