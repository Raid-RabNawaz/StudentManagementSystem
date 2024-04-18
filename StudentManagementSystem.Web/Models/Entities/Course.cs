using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Web.Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string CourseCode { get; set; }

        [Required]
        public string CourseName { get; set; }

        public string TeacherName { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int MaxCapacity { get; set; }

        public virtual ICollection<Student>? Students { get; set; }
    }
}
