using StudentManagementSystem.Web.Models.Entities;
using StudentManagementSystem.Web.Repositories;

namespace StudentManagementSystem.Web.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void AddCourse(Course course)
        {
            _courseRepository.Add(course);
        }


        public IEnumerable<Course> GetAllCourses()
        {
            var courses = _courseRepository.GetAllCourses();
            return courses;
        }

        public Course GetCourseById(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            
            return course;
        }

        public IEnumerable<Course> GetCourses(int page, int pageSize, string search)
        {
            return _courseRepository.GetCourses(page, pageSize, search);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
        }

        public void DeleteCourse(int courseId)
        {
            _courseRepository.Delete(courseId);
        }
    }
}
