using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementSystem.Web.Models.Entities;
using StudentManagementSystem.Web.Services;

namespace StudentManagementSystem.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public StudentController(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }

        public ActionResult Index(int page = 1, string search = "")
        {
            var pageSize = 10; // Number of students per page
            var students = _studentService.GetStudents(page, pageSize, search);
            return View(students);
        }

        public ActionResult Create()
        {
            ViewBag.Courses = _courseService.GetAllCourses();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.AddStudent(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }


        public ActionResult Register(int studentId)
        {
            var student = _studentService.GetStudentById(studentId);
            var courses = _studentService.GetAvailableCoursesForStudent(studentId);
            ViewBag.StudentName = student.FirstName + " " + student.Surname;
            ViewBag.StudentId = student.StudentId;
            ViewBag.Courses = new SelectList(courses, "CourseId", "CourseName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(int studentId, int courseId)
        {
            _studentService.RegisterCourse(studentId, courseId);
            return RedirectToAction("Index");
        }

        // GET: Student/Edit/5
        public IActionResult Edit(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _studentService.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public IActionResult Delete(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}

