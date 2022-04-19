using System.Collections.Generic;
using System.Linq;

namespace BrowseCourses.Models
{

    public class EFCourseRepository : ICourseRepository
    {
        private ApplicationDbContext context;

        public EFCourseRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Course> Courses => context.Courses;


        public void SaveCourse(Course course)
        {
            if (course.CourseID == 0)
            {
                course.CourseID = context.Courses.Count()+1;
                context.Courses.Add(course);
            }
            else
            {
                Course dbEntry = context.Courses.FirstOrDefault(p => p.CourseID == course.CourseID);
                if (dbEntry != null)
                {
                    dbEntry.CourseNumber = course.CourseNumber;
                    dbEntry.Description = course.Description;
                    dbEntry.Credits = course.Credits;
                    //dbEntry.CourseID
                }
            }
            context.SaveChanges();
        }

        public Course DeleteCourse(int courseID)
        {
            Course dbEntry = context.Courses.FirstOrDefault(p => p.CourseID == courseID);
            if (dbEntry != null)
            {
                context.Courses.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}