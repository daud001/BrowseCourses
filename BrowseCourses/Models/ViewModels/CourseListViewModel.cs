using System.Collections.Generic;
using BrowseCourses.Models;

namespace BrowseCourses.Models.ViewModels
{

    public class CoursesListViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}