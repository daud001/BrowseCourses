using Microsoft.AspNetCore.Mvc;
using BrowseCourses.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;


namespace BrowseCourses.Controllers
{

    public class PlanDetailController : Controller
    {
        private IPlanDetailRepository repository;
        private Plan plan;

        public PlanDetailController(IPlanDetailRepository repoService, Plan planService)
        {
            repository = repoService;
            plan = planService;
        }

        [Authorize]
        public ViewResult List() => View(repository.PlanDetails);

        [HttpPost]
        [Authorize]
        public IActionResult MarkCurrentPlan(int planID)
        {
            PlanDetail planDetail = repository.PlanDetails.FirstOrDefault(o => o.PlanID == planID);
            if (planDetail != null)
            {
                planDetail.Registered = true;
                repository.SavePlanDetail(planDetail);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Saveplan() => View(new PlanDetail());


        [HttpPost]
        public IActionResult Saveplan(PlanDetail planDetail)
        {
            if (plan.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your plan is empty!");
            }
            if (ModelState.IsValid)
            {
                planDetail.Lines = plan.Lines.ToArray();
                repository.SavePlanDetail(planDetail);
                return RedirectToAction(nameof(Enrolled));
            }
            else
            {
                return View(planDetail);
            }
        }

        public ViewResult Enrolled()
        {
            plan.Clear();
            return View();
        }

    }
}