using StudentManagementSystem.Web.Models.Entities;

namespace StudentManagementSystem.Web.Services
{
    public interface ICourseService
    {
        void AddCourse(Course course);
        IEnumerable<Course> GetCourses(int page, int pageSize, string search);
        IEnumerable<Course> GetAllCourses();

        Course GetCourseById(int id);

        void UpdateCourse(Course course);
        void DeleteCourse(int courseId);
    }
}
