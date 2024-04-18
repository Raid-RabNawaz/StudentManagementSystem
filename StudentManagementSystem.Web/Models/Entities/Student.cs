using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Web.Models.Entities
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        public virtual ICollection<Course>? Courses { get; set; }
    }
}
