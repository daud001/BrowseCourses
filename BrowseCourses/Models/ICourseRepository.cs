using System.Linq;

namespace BrowseCourses.Models {

    public interface ICourseRepository {

        IQueryable<Course> Courses { get; }

        void SaveCourse(Course course);

        Course DeleteCourse(int courseID);

    }
}
