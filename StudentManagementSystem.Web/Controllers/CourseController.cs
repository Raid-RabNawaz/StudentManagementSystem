using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Web.Models.Entities;
using StudentManagementSystem.Web.Services;

namespace StudentManagementSystem.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService coursetService)
        {
            _courseService = coursetService;
        }

        public ActionResult Index(int page = 1, string search = "")
        {
            var pageSize = 10; // Number of students per page
            var students = _courseService.GetCourses(page, pageSize, search);
            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseService.AddCourse(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

     
        public IActionResult Edit(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _courseService.UpdateCourse(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

         
        public IActionResult Delete(int id)
        {
            var student = _courseService.GetCourseById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var student = _courseService.GetCourseById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

    }
}
