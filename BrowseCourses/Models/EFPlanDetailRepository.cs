using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BrowseCourses.Models
{

    public class EFPlanDetailRepository : IPlanDetailRepository
    {
        private ApplicationDbContext context;

        public EFPlanDetailRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<PlanDetail> PlanDetails => context.PlanDetails.Include(o => o.Lines).ThenInclude(l => l.Course);

        public void SavePlanDetail(PlanDetail planDetail)
        {
            //context.PlanDetails.AsNoTracking();
            context.AttachRange(planDetail.Lines.Select(l => l.Course));
            if (planDetail.PlanID == 0) {
                context.PlanDetails.Add(planDetail);
            }
            context.SaveChanges();
        }
    }
}