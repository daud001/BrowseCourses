using System.Collections.Generic;
using System.Linq;

namespace BrowseCourses.Models {

        public class FakeProductRepository /* : IProductRepository */
        {
            public IQueryable<Course> Courses => new List<Course> {
            new Course { CourseNumber = "CSC312", Description="Software Engineering", Credits = 3 },
            new Course { CourseNumber = "INFS234", Description="Data Manipulation", Credits = 3 },
            new Course { CourseNumber = "ACT434", Description="Advanced Accounting",Credits = 3 }
        }.AsQueryable<Course>();
    }
}
