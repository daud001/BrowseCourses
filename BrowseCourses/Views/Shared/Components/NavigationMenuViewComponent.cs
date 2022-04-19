using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BrowseCourses.Models;

namespace BrowseCourses.Components
{

    public class NavigationMenuViewComponent : ViewComponent
    {
        private ICourseRepository repository;

        public NavigationMenuViewComponent(ICourseRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            var categoryList = this.repository.Courses.Select(x => x.CourseNumber).OrderBy(x =>x).ToList();
            for(int i = 0; i < categoryList.Count; i++)
            {
                if (categoryList[i].Contains(" ") && categoryList[i].Any(char.IsDigit))
                    categoryList[i] = categoryList[i].Split(" ").First().ToUpper();
                else
                    categoryList[i] = categoryList[i];
            }
            var newList = categoryList.Distinct().ToList();
            return View(newList);
        }
    }
}