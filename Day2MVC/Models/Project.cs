using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2MVC.Models
{
    public class Project
    {
        [Key]
        public int PNumber { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(5, ErrorMessage = "Name must be more or equal 5 letters")]
        public string? PName { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string? Loc { get; set; }
        public List<Works_On>? works_Ons { get; set; }
        public Department? department { get; set; }
        [ForeignKey("department")]
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
    }
}
