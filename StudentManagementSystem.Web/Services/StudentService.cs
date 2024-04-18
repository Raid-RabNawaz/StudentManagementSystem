using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Web.Models.Entities;
using StudentManagementSystem.Web.Repositories;

namespace StudentManagementSystem.Web.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
        }

        public Student GetStudentById(int studentId)
        {
            var student = _studentRepository.GetStudentById(studentId);
            return student; 
        }

        public IEnumerable<Student> GetStudents(int page, int pageSize, string search)
        {
            return _studentRepository.GetStudents(page, pageSize, search);
        }

        public void RegisterCourse(int studentId, int courseId)
        {
            var student = _studentRepository.GetStudentById(studentId);
            var course = _courseRepository.GetCourseById(courseId);

            // Ensure student.Courses is initialized
            if (student.Courses == null)
            {
                student.Courses = new List<Course>();
            }
            // Ensure course.Students is initialized
            if (course.Students == null)
            {
                course.Students = new List<Student>();
            }

            if (student != null && course != null)
            {
                if (student.Courses.Count < 5 && course.Students.Count < course.MaxCapacity)
                {
                    if (!student.Courses.Contains(course) && !course.Students.Contains(student))
                    {
                        student.Courses.Add(course);
                        course.Students.Add(student);
                        _studentRepository.SaveChanges();
                    }
                }
            }
        }

        public IEnumerable<Course> GetAvailableCoursesForStudent(int studentId)
        {
            // Retrieve the student from the database including their enrolled courses
             
            var student = _studentRepository.GetStudentById(studentId);
            if (student.Courses == null)
            {
                // Student not found, return empty list or handle accordingly
                return _courseRepository.GetAllCourses();
            }

            var registeredCourses = student.Courses.Select(c => c.CourseId).ToList();
            return _courseRepository.GetAllCourses().Where(c => !registeredCourses.Contains(c.CourseId));
        }

        public void SaveChanges()
        {
            _studentRepository.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public void DeleteStudent(int studentId)
        {
            _studentRepository.Delete(studentId);
        }
    }
}
