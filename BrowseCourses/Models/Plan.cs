using System.Collections.Generic;
using System.Linq;

namespace BrowseCourses.Models
{

    public class Plan
    {
        private List<PlanLine> lineCollection = new List<PlanLine>();

        public virtual void AddItem(Course course, int quantity)
        {
            PlanLine line = lineCollection
                .Where(p => p.Course.CourseID == course.CourseID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new PlanLine
                {
                    Course = course,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Course course) =>
            lineCollection.RemoveAll(l => l.Course.CourseID == course.CourseID);

        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(e => e.Course.Credits * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<PlanLine> Lines => lineCollection;
    }

    public class PlanLine
    {
        public int PlanLineID { get; set; }
        public Course Course { get; set; }
        public int Quantity { get; set; }
    }
}