using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrowseCourses.Models
{
    //[Microsoft.EntityFrameworkCore.Keyless]
    public class PlanDetail
    {
        [BindNever]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int PlanID { get; set; }

        [BindNever]
        public bool Registered { get; set; }



        [BindNever]
        //[Required(ErrorMessage = "Please enter a line")]
        public ICollection<PlanLine>? Lines { get; set; }



        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
    }
}