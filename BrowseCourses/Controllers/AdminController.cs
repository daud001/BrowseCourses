using Microsoft.AspNetCore.Mvc;
using BrowseCourses.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace BrowseCourses.Controllers
{ 
    [Authorize]
    public class AdminController : Controller
    {
        private ICourseRepository repository;

        public AdminController(ICourseRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Courses);

        public ViewResult Edit(int courseId) => View(repository.Courses.FirstOrDefault(p => p.CourseID == courseId));

        [HttpPost]
        public IActionResult Edit(Course course)
        {

            if (ModelState.IsValid)
            {
                repository.SaveCourse(course);
                TempData["message"] = $"{course.CourseNumber} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values                
                return View(course);
            }
        }

        public ViewResult Create() => View("Edit", new Course());


        [HttpPost]
        public IActionResult Delete(int courseId)
        {
            Course deletedCourse = repository.DeleteCourse(courseId);
            if (deletedCourse != null)
            {
                TempData["message"] = $"{deletedCourse.CourseNumber} was deleted";
            }
            return RedirectToAction("Index");
        }

    }
}