using StudentManagementSystem.Web.Models.Entities;

namespace StudentManagementSystem.Web.Services
{
    public interface IStudentService
    {
        void AddStudent(Student student);

        IEnumerable<Student> GetStudents(int page, int pageSize, string search);

        void RegisterCourse(int studentId, int courseId);

        Student GetStudentById(int studentId);

        IEnumerable<Course> GetAvailableCoursesForStudent(int studentId);
        void SaveChanges();
        void UpdateStudent(Student student);
        void DeleteStudent(int studentId);
    }
}
