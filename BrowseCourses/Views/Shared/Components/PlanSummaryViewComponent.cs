using Microsoft.AspNetCore.Mvc;
using BrowseCourses.Models;

namespace BrowseCourses.Components
{

    public class PlanSummaryViewComponent : ViewComponent
    {
        private Plan plan;

        public PlanSummaryViewComponent(Plan planService)
        {
            plan = planService;
        }

        public IViewComponentResult Invoke()
        {
            return View(plan);
        }
    }
}