using StudentManagementSystem.Web.Models.Entities;

namespace StudentManagementSystem.Web.Repositories
{
    public interface IStudentRepository
    {
        void Add(Student student);

        IEnumerable<Student> GetStudents(int page, int pageSize, string search);

        Student GetStudentById(int studentId);

        void SaveChanges();

        void Update(Student student);
        void Delete(int studentId);
    }
}
