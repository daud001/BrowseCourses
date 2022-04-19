using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BrowseCourses.Infrastructure;
using BrowseCourses.Models;
using BrowseCourses.Models.ViewModels;

namespace BrowseCourses.Controllers
{

    public class PlanController : Controller
    {
        private ICourseRepository repository;
        private Plan plan;

        public PlanController(ICourseRepository repo, Plan planService)
        {
            repository = repo;
            plan = planService;
        }


        public ViewResult Index(string returnUrl)
        {
            return View(new PlanIndexViewModel
            {
                Plan = plan,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToPlan(int courseId, string returnUrl)
        {
            Course course = repository.Courses
                .FirstOrDefault(p => p.CourseID == courseId);

            if (course != null)
            {
                plan.AddItem(course, 1);
               
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromPlan(int courseId, string returnUrl)
        {
            Course course = repository.Courses
                .FirstOrDefault(p => p.CourseID == courseId);

            if (course != null)
            {
                plan.RemoveLine(course);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

    }
}