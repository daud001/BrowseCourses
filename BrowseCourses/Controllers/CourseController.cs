using System;
using Microsoft.AspNetCore.Mvc;
using BrowseCourses.Models;
using System.Linq;
using BrowseCourses.Models.ViewModels;

namespace BrowseCourses.Controllers {

    public class CourseController : Controller {
        private ICourseRepository repository;
        public int PageSize = 4;

        public CourseController(ICourseRepository repo) {
            repository = repo;
        }

        public ViewResult List(string category, int coursePage = 1)
            => View(new CoursesListViewModel
            {
                Courses = repository.Courses
                    .Where(p => (category == null) || (p.CourseNumber.Contains(category)))
                    .OrderBy(p => p.CourseNumber)
                    .Skip((coursePage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = coursePage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Courses.Count() :
                        repository.Courses.Where(e =>
                            e.CourseNumber.Contains(category)).Count()
                },
                CurrentCategory = category
            });
    }
}
