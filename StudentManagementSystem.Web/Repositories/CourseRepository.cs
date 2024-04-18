using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Web.Data;
using StudentManagementSystem.Web.Models.Entities;

namespace StudentManagementSystem.Web.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var courseList = _context.Courses.AsQueryable();

            return courseList;
        }

        public Course GetCourseById(int id)
        {
            var courses = _context.Courses.AsQueryable();
            var course = courses.FirstOrDefault(c => c.CourseId==id);

            if (course == null)
            {
                course = new Course();
            }

            return course;
        }

        public IEnumerable<Course> GetCourses(int page, int pageSize, string search)
        {
            var courses = _context.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                courses = courses.Where(c =>
                    c.CourseCode.Contains(search) || c.CourseName.Contains(search));
            }

            return courses.OrderBy(c => c.CourseId)
                          .Skip((page - 1) * pageSize)
                          .Take(pageSize)
                          .ToList();
        }

        public void Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int courseId)
        {
            var course = _context.Courses.Find(courseId);
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }

    }
}
