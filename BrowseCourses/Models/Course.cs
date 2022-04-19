using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BrowseCourses.Models {

    public class Course {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Please enter the course number")]
        public string CourseNumber { get; set; }

        [Required]
        [Range(1, 100,
            ErrorMessage = "Please enter a positive value")]
        public int Credits { get; set; }

        [Required(ErrorMessage = "Please enter the course description")]
        public string Description { get; set; }

    }
}
