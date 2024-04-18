using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Web.Data;
using StudentManagementSystem.Web.Models.Entities;

namespace StudentManagementSystem.Web.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public Student GetStudentById(int studentId)
        {
            var student = _context.Students
                            .Include(s => s.Courses) // Include related courses
                            .FirstOrDefault(s => s.StudentId == studentId);

            if (student == null)
            {
                student = new Student();

            } 

            return student;
        }

        public IEnumerable<Student> GetStudents(int page, int pageSize, string search)
        {
            var students = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(s =>
                    s.FirstName.Contains(search) || s.Surname.Contains(search));
            }

            return students.OrderBy(s => s.StudentId)
                           .Skip((page - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        public void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int studentId)
        {
            var student = _context.Students.Find(studentId);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}
