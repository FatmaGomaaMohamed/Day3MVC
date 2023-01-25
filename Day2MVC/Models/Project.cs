using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2MVC.Models
{
    public class Project
    {
        [Key]
        public int PNumber { get; set; }
        public string? PName { get; set; }
        public string? Loc { get; set; }
        public List<Works_On>? works_Ons { get; set; }
        public Department? department { get; set; }
        [ForeignKey("department")]
        public int? DepartmentId { get; set; }
    }
}
