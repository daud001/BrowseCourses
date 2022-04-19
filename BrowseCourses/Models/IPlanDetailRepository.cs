using System.Linq;

namespace BrowseCourses.Models
{

    public interface IPlanDetailRepository
    {

        IQueryable<PlanDetail> PlanDetails { get; }
        void SavePlanDetail(PlanDetail planDetail);
    }
}