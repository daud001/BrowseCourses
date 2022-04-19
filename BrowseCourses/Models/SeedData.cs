using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BrowseCourses.Models
{

    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course
                    {
                        CourseID = 1,
                        CourseNumber = "Gen Req",
                        Description = "System-wide Gen Ed requirements",
                        Credits = 30
                    },
                    new Course
                    {
                        CourseID = 2,
                        CourseNumber="Inst Req",
                        Description = "Institutional Graduation Requirements",
                        Credits = 11
                    },
                    new Course
                    {
                        CourseID = 3,
                        CourseNumber="Acct 210",
                        Description = "Principles of Accounting",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 4,
                        CourseNumber="BADM 220",
                        Description = "Business Statistics",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 5,
                        CourseNumber="BADM 344",
                        Description = "Manegerial Communications",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 6,
                        CourseNumber="BADM 350",
                        Description = "Legal Environment of Business",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 7,
                        CourseNumber="BADM 360",
                        Description = "Organization and Management",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 8,
                        CourseNumber="BADM 370",
                        Description = "Marketing",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 9,
                        CourseNumber="CIS 351",
                        Description = "Business Applications Programming",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID =10,
                        CourseNumber="CIS 325",
                        Description = "Management Information Systems",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 11,
                        CourseNumber="CIS 332",
                        Description = "Structured Systems Analysis and Design",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 12,
                        CourseNumber="CIS 388",
                        Description = "Project Management",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 13,
                        CourseNumber="CIS 427",
                        Description = "Information Systems Planning and Management",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 14,
                        CourseNumber="CIS 484",
                        Description = "Database Management Systems",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 15,
                        CourseNumber="Experience",
                        Description = "Internship or Research",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 16,
                        CourseNumber="CSC 363",
                        Description = "Hardware, Virtualization, and Data Communications",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 17,
                        CourseNumber="CSC 245",
                        Description = "Information Security Fundamentals",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 18,
                        CourseNumber="CIS 275",
                        Description = "Web Application Programming",
                        Credits = 3
                    },new Course
                    {
                        CourseID =19,
                        CourseNumber="CIS 361",
                        Description = "Advanced Programming for Business Apps",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 20,
                        CourseNumber="CIS 375",
                        Description = "Web Application Programming ||",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 21,
                        CourseNumber="CIS 424",
                        Description = "Software Development with Agile Methodologies",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 22,
                        CourseNumber="CIS 487",
                        Description = "Database Programming",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 23,
                        CourseNumber="MATH 201",
                        Description = "Introduction to Discrete Mathematics",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 24,
                        CourseNumber="Electives",
                        Description = "Electives",
                        Credits = 16
                    }
                );
                context.SaveChanges();
            }
        }
    }
}