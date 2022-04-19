using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using BrowseCourses.Infrastructure;

namespace BrowseCourses.Models
{

    public class SessionPlan : Plan
    {

        public static Plan GetPlan(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionPlan plan = session?.GetJson<SessionPlan>("Plan")
                ?? new SessionPlan();
            plan.Session = session;
            return plan;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Course course, int quantity)
        {
            base.AddItem(course, quantity);
            Session.SetJson("Plan", this);
        }

        public override void RemoveLine(Course course)
        {
            base.RemoveLine(course);
            Session.SetJson("Plan", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Plan");
        }
    }
}