using StudentManagementSystem.Web.Models.Entities;

namespace StudentManagementSystem.Web.Repositories
{
    public interface ICourseRepository
    {
        void Add(Course course);
        IEnumerable<Course> GetCourses(int page, int pageSize, string search);

        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int id);

        void Update(Course course);
        void Delete(int courseId);
    }
}
